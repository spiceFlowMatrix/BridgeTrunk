
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CourseRoutingModule } from './course-routing.module';
import { CourseListComponent } from './components/course-list/course-list.component';
import { CommonUiModule } from '@js-mono/common-ui';
import { CourseDetailComponent } from './components/course-detail/course-detail.component';



@NgModule({
  declarations: [CourseListComponent, CourseDetailComponent],
  imports: [
    CommonModule,
    CommonUiModule,
    CourseRoutingModule
  ]
})
export class CourseModule { }
