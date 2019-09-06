using Npgsql;
using NpgsqlTypes;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Store.BusinessLogic.Services
{
    public class SpaDatasourceServices : ISpaDatasource, IDisposable
    {
        #region Атрибуты

        private bool _IsAlreadyDisposed = false;

        private string _ConnectionString;
        private NpgsqlConnection _Conn;

        #endregion

        #region Инициализация и освобождение ресурсов

        public SpaDatasourceServices(string connString)
        {
            _ConnectionString = connString;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_IsAlreadyDisposed)
                return;

            if (isDisposing)
            {
                // освобождаем управляемые ресурсы тут
                Close();
            }

            // если есть неуправляемые ресурсы - то их нужно совободить тут

            _IsAlreadyDisposed = true;
        }

        #endregion

        #region Открытие и закрытие соединения с БД

        public void Open()
        {
            if (_IsAlreadyDisposed)
                throw new ObjectDisposedException("MyDbContext", "Called [Open] method on disposed object.");

            if (_Conn != null)
            {
                if (_Conn.State != System.Data.ConnectionState.Closed && _Conn.State != System.Data.ConnectionState.Broken)
                    throw new InvalidOperationException("Called [Open] on already opened connection.");
            }

            _Conn = new NpgsqlConnection(_ConnectionString);
            _Conn.Open();
        }

        public void Close()
        {
            if (_Conn == null)
                return;

            if (_Conn.State == System.Data.ConnectionState.Closed || _Conn.State == System.Data.ConnectionState.Broken)
                return;

            _Conn.Close();
        }

        #endregion

        #region Работа с пользователями

        public User FindUserById(string id)
        {
            CheckConnValidity("FindUserById");

            string sql = "SELECT id, username, password_hash, first_name FROM users WHERE id = :id";
            NpgsqlCommand command = CreateCommandWithTimeout(sql, _Conn);
            command.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            command.Parameters[0].Value = id;

            return GetUserFromCommand(command);
        }

        public User FindUserByName(string name)
        {
            CheckConnValidity("FindUserByName");

            string sql = "SELECT id, username, password_hash, first_name FROM users WHERE username = :username";
            NpgsqlCommand command = CreateCommandWithTimeout(sql, _Conn);
            command.Parameters.Add(new NpgsqlParameter("username", NpgsqlDbType.Text));
            command.Parameters[0].Value = name;

            return GetUserFromCommand(command);
        }

        public void InsertUser(User user)
        {
            CheckConnValidity("InsertUser");

            string sql = "INSERT INTO users (username, password_hash, first_name) VALUES (:username, :password_hash, :first_name) RETURNING id";
            NpgsqlCommand command = CreateCommandWithTimeout(sql, _Conn);

            command.Parameters.Add(new NpgsqlParameter("username", NpgsqlDbType.Text));
            command.Parameters[0].Value = user.UserName;

            command.Parameters.Add(new NpgsqlParameter("password_hash", NpgsqlDbType.Text));
            command.Parameters[1].Value = user.PasswordHash;

            command.Parameters.Add(new NpgsqlParameter("first_name", NpgsqlDbType.Text));
            command.Parameters[2].Value = user.FirstName;

            string id = (string)command.ExecuteScalar();

            user.Id = id;
        }

        public void UpdateUser(User user)
        {
            CheckConnValidity("UpdateUser");

            string sql = "UPDATE users SET username = :username, password_hash = :password_hash, first_name = :first_name";
            NpgsqlCommand command = CreateCommandWithTimeout(sql, _Conn);

            command.Parameters.Add(new NpgsqlParameter("id", NpgsqlDbType.Integer));
            command.Parameters[0].Value = user.Id;

            command.Parameters.Add(new NpgsqlParameter("username", NpgsqlDbType.Text));
            command.Parameters[0].Value = user.UserName;

            command.Parameters.Add(new NpgsqlParameter("password_hash", NpgsqlDbType.Text));
            command.Parameters[1].Value = user.PasswordHash;

            command.Parameters.Add(new NpgsqlParameter("first_name", NpgsqlDbType.Text));
            command.Parameters[2].Value = user.FirstName;

            command.ExecuteNonQuery();
        }

        public IEnumerable<User> Users()
        {
            CheckConnValidity("Users");

            List<User> list = new List<User>();

            string sql = "SELECT id, username, password_hash, first_name FROM users";
            NpgsqlCommand command = CreateCommandWithTimeout(sql, _Conn);

            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                User u = GetUserFromDataReader(dr);
                list.Add(u);
            }

            dr.Close();

            return list;
        }

        #endregion

        

        #region Вспомогательные классы

        private void CheckConnValidity(string methodName)
        {
            if (_IsAlreadyDisposed)
                throw new ObjectDisposedException("MyDbContext", "Called [" + methodName + "] method on disposed object.");

            if (_Conn == null)
                throw new InvalidOperationException("Called [" + methodName + "] method on null connection object.");

            if (_Conn.State == System.Data.ConnectionState.Closed)
                throw new InvalidOperationException("Called [" + methodName + "] method on closed connection object.");

            if (_Conn.State == System.Data.ConnectionState.Broken)
                throw new InvalidOperationException("Called [" + methodName + "] method on broken connection object.");
        }

        private NpgsqlCommand CreateCommandWithTimeout(string cmdText, NpgsqlConnection conn, int Timeout = 30)
        {
            NpgsqlCommand command = new NpgsqlCommand(cmdText, conn)
            {
                CommandTimeout = Timeout
            };

            return command;
        }

        private User GetUserFromCommand(NpgsqlCommand command)
        {
            User user = null;

            NpgsqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                user = GetUserFromDataReader(dr);
            }

            dr.Close();

            return user;
        }

        private User GetUserFromDataReader(NpgsqlDataReader dr)
        {
            return new User
            {
                Id = dr.GetString(0),
                UserName = dr.GetString(1),
                PasswordHash = dr.GetString(2),
                FirstName = dr.IsDBNull(3) ? null : dr.GetString(3)
            };
        }

        IEnumerable ISpaDatasource.Users()
        {
            CheckConnValidity("Users");

            List<User> list = new List<User>();

            string sql = "SELECT id, username, password_hash, first_name FROM users";
            NpgsqlCommand command = CreateCommandWithTimeout(sql, _Conn);

            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                User u = GetUserFromDataReader(dr);
                list.Add(u);
            }

            dr.Close();

            return list;
        }


        #endregion
    }
}
