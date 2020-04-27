import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';


@NgModule({
  imports: [CommonModule, MatToolbarModule, MatMenuModule, MatButtonModule, MatIconModule, MatSidenavModule],
  declarations: [ToolbarComponent, SideNavComponent],
  exports: [ToolbarComponent, SideNavComponent]
})
export class CommonUiModule { }
