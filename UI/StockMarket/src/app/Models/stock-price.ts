import { Time } from '@angular/common';
import { Company } from './company';

export interface StockPrice {
    id:number;
    companyCode:string;
    stockExchange:string;
    currentPrice:number;
    date:Date;
    time:Time;
}
