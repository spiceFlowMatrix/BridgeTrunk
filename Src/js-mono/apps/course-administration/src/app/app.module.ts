import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';

// Libraries import
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UiComponentsComponent } from './components/ui-components/ui-components.component';
import { AppRoutingModule } from './app-routing.module';
import { CommonUiModule } from '@js-mono/common-ui';


@NgModule({
  declarations: [AppComponent, UiComponentsComponent],
  imports: [
    BrowserModule,
    CommonUiModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
