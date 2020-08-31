import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-import-excel',
  templateUrl: './import-excel.component.html',
  styleUrls: ['./import-excel.component.css']
})
export class ImportExcelComponent implements OnInit {
  loading:boolean = false;
  @ViewChild('excelForm') form:NgForm;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(formData:any):void{
    console.log(formData); 
  }

  downloadSample(){}

}
