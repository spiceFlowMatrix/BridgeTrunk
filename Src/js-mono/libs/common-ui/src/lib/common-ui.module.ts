import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatPaginatorModule } from '@angular/material/paginator';


import { ButtonComponent } from './button/button.component';
import { SubHeaderComponent } from './sub-header/sub-header.component';
import { MultiSelectTableComponent } from './multi-select-table/multi-select-table.component';


@NgModule({
  imports: [CommonModule, MatToolbarModule, MatMenuModule, MatButtonModule, MatIconModule, MatSidenavModule, MatTableModule, MatCheckboxModule, MatPaginatorModule],
  declarations: [ToolbarComponent, SideNavComponent, ButtonComponent, SubHeaderComponent, MultiSelectTableComponent],
  exports: [ToolbarComponent, SideNavComponent, ButtonComponent, SubHeaderComponent, MultiSelectTableComponent]
})
export class CommonUiModule { }
