import { NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { routing, routedComponents } from './app.routing';
import { AppComponent } from './app.component';
//import { FormsModule } from '@angular/forms';
//import { HttpModule } from '@angular/http';
//import { ReactiveFormsModule } from '@angular/forms';
//import { SampleDataService } from './services/SampleData.services';
import './rxjs-operators';

// enableProdMode();

@NgModule({
    imports: [BrowserModule, /*ReactiveFormsModule, FormsModule, HttpModule,*/ routing],
    declarations: [AppComponent, routedComponents],
    providers: [],
    bootstrap: [AppComponent]
})

export class AppModule { }