import { Time } from '@angular/common';

export interface StockPrice {
    id:number;
    companyCode:string;
    stockExchange:string;
    currentPrice:number;
    date:Date;
    time:Time;
}
