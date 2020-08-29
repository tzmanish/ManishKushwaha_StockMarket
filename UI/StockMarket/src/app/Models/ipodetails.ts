export interface IPODetails {
    id:number;
    companyCode:string;
    stockExchange:string;
    pricePerShare:number;
    totalShares:number;
    dateTime?:Date;
    remrks?:string;
}
