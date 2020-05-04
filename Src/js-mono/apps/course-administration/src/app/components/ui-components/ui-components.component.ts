import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'js-mono-ui-components',
  templateUrl: './ui-components.component.html',
  styleUrls: ['./ui-components.component.scss']
})
export class UiComponentsComponent implements OnInit {

  buttonsCodeSnippet = '';
  constructor() { }

  ngOnInit(): void {
    this.buttonsCodeSnippet = `<js-mono-button [type]="'save'" [text]="'save'"></js-mono-button>`
  }

}
