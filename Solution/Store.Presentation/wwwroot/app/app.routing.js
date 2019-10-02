"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var about_component_1 = require("./about.component");
var index_component_1 = require("./index.component");
var signin_component_1 = require("./signin.component");
var registration_component_1 = require("./account.module/components/registration/registration.component");
var contact_component_1 = require("./contact.component");
var appRoutes = [
    { path: '', redirectTo: 'app.component.html', pathMatch: 'full' },
    { path: 'home', component: index_component_1.IndexComponent, data: { title: 'Home' } },
    { path: 'about', component: about_component_1.AboutComponent, data: { title: 'About' } },
    { path: 'signin', component: signin_component_1.SignInComponent, data: { title: 'SignIn' } },
    { path: 'registration', component: registration_component_1.RegistrationComponent, data: { title: 'Registration' } },
    { path: 'contact', component: contact_component_1.ContactComponent, data: { title: 'Contact' } },
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
exports.routedComponents = [about_component_1.AboutComponent, index_component_1.IndexComponent, signin_component_1.SignInComponent, registration_component_1.RegistrationComponent, contact_component_1.ContactComponent];
//# sourceMappingURL=app.routing.js.map