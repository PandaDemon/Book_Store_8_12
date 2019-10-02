"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var platform_browser_1 = require("@angular/platform-browser");
//import { UserService } from './services/user.service';
var must_match_validator_1 = require("./must-match.validator");
var RegistrationComponent = (function () {
    function RegistrationComponent(/*public service: UserService,*/ formBuilder, titleService) {
        this.formBuilder = formBuilder;
        this.titleService = titleService;
        this.formModel = {
            UserName: '',
            Password: ''
        };
        this.submitted = false;
        this.angularClientSideData = 'Angular';
    }
    RegistrationComponent.prototype.setTitle = function (newTitle) {
        this.titleService.setTitle(newTitle);
    };
    RegistrationComponent.prototype.ngOnInit = function () {
        this.registerForm = this.formBuilder.group({
            firstName: ['', forms_1.Validators.required],
            lastName: ['', forms_1.Validators.required],
            email: ['', [forms_1.Validators.required, forms_1.Validators.email]],
            password: ['', [forms_1.Validators.required, forms_1.Validators.minLength(6)]],
            confirmPassword: ['', forms_1.Validators.required]
        }, {
            validator: must_match_validator_1.MustMatch('password', 'confirmPassword')
        });
    };
    Object.defineProperty(RegistrationComponent.prototype, "f", {
        get: function () { return this.registerForm.controls; },
        enumerable: true,
        configurable: true
    });
    RegistrationComponent.prototype.onSubmit = function () {
        this.submitted = true;
        if (this.registerForm.invalid) {
            return;
        }
        alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value));
        //this.service.register().subscribe(
        //    (res: any) => {
        //        console.log(res.succeeded);
        //        if (res.succeeded) {
        //            console.log(res.succeeded);
        //            this.toastr.success('New user created', 'Registration successful');
        //            this.router.navigateByUrl('/user/confirm');
        //        } else {
        //            res.errors.forEach(element => {
        //                console.log(element);
        //                this.toastr.error(element.code, 'registration failed')
        //            });
        //        }
        //    },
        //    err => {
        //        console.log(err);
        //    }
        //);
    };
    RegistrationComponent = __decorate([
        core_1.Component({
            selector: 'my-registration',
            templateUrl: '/partial/registrationComponent'
        }),
        __metadata("design:paramtypes", [forms_1.FormBuilder, platform_browser_1.Title])
    ], RegistrationComponent);
    return RegistrationComponent;
}());
exports.RegistrationComponent = RegistrationComponent;
//# sourceMappingURL=registration.component.js.map