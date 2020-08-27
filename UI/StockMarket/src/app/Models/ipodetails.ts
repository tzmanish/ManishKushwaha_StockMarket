export interface IPODetails {
    Id:number;
    CompanyCode:string;
    StockExchange:string;
    PricePerShare:number;
    TotalShares:number;
    DateTime?:Date;
    Remrks?:string;
}
