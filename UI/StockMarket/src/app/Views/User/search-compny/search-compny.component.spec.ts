import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchCompnyComponent } from './search-compny.component';

describe('SearchCompnyComponent', () => {
  let component: SearchCompnyComponent;
  let fixture: ComponentFixture<SearchCompnyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchCompnyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchCompnyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
