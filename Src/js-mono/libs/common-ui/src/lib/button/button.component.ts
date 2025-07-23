import { Component, OnInit, Input, EventEmitter } from '@angular/core';

@Component({
  selector: 'js-mono-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
  @Input() btnClass: string;
  @Input() type: string;
  @Input() text: string;
  @Input() isSubmit = false;
  @Input() click = new EventEmitter<any>();
  @Input() disabled = false;

  btnType = '';
  constructor() { }

  ngOnInit(): void {
  }
  btnClick():void {
    this.click.emit();
  }

}
