import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'js-mono-sub-header',
  templateUrl: './sub-header.component.html',
  styleUrls: ['./sub-header.component.scss']
})
export class SubHeaderComponent implements OnInit {

  @Input() headerClass = 'sub_header_template_main';
  constructor() { }
  

  ngOnInit(): void {
  }

}
