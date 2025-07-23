import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MultiSelectTableComponent } from './multi-select-table.component';

describe('MultiSelectTableComponent', () => {
  let component: MultiSelectTableComponent;
  let fixture: ComponentFixture<MultiSelectTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MultiSelectTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MultiSelectTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
