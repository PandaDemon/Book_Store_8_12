
using Store.DataAccess.Repositories.Interfaces;

namespace Store.BusinessLogic.Services
{
    public class DataManager
    {
        private IAuthor _author;
        private ICategory _category;
        private IPrintingEdition _printingEdition;

        public DataManager(IAuthor author, ICategory category, IPrintingEdition printingEdition)
        {
            _author = author;
            _category = category;
            _printingEdition = printingEdition;
        }

        public IAuthor Author { get { return _author; } }
        public ICategory Category { get { return _category; } }
        public IPrintingEdition PrintingEdition { get { return _printingEdition; } }
    }
}
