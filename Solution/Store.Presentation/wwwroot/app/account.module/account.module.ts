import { NgModule, enableProdMode } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
//import { routing, routedComponents } from '';
import { APP_BASE_HREF, Location } from '@angular/common';
//import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ReactiveFormsModule } from '@angular/forms';
//import { SampleDataService } from './services/SampleData.services';
import './rxjs-operators';

// enableProdMode();

@NgModule({
    //imports: [BrowserModule, ReactiveFormsModule, FormsModule, HttpModule, routing],
    //declarations: [AppComponent, routedComponents],
    ////providers: [SampleDataService, Title, { provide: APP_BASE_HREF, useValue: '/' }],
    //bootstrap: [AppComponent]
})

export class AppModule { }