# .Net web APIs with Angular (Microservice Architecture - Practice Project)

## Business Requirement (Stock Market Charting)

This Software System lets Admin to upload Stock Price of a Company(which is listed in a Stock Exchange) at different points of time. It need to support multiple Stock Exchanges. And the registered Users should be able to generate various charts to perform Stock Market performance of various Companies or Sectors over certain period of time. More details on the features which need to be supported are specified, below.  
This Case study supports below two different Roles:

  1. Admin
  2. User

### Admin Use Cases

  1. Login/Logout
  2. Manage Company:  
    1. Add a new company details with fields or edit an already existing Company details  
    2. Deactivate an already existing company  
    3. Update any IPO related data  
  3. Import Data(Excel Format):  
    1. Data can be imported(in Excel format), it's basically to feed stock price of a company at various points of time. [this](https://github.com/santuparsi/StockMarketCharting/sample_stock_data.xlsx) is sample Excel format, which can be used.
    2. Uploaded Excel need to be in a specific format, if not error message need to be displayed. While uploading Excel, specify the Stock Exchange to which the uploaded data belong to. If such company exists.  
    3. The company code, date ranges need to be appropriately checked, if any data will be over written.  
    4. After successfully imported, data need to get stored in a database and Uploaded Summary need to be displayed like which company, Stock Exchange, how many records imported, from and to date range, etc…  
  4. Missing Data: Able to check the dates for which Stock Price of a Company is not available

### User Use Cases

  1. User Signup/Login/Logout: An User can  
    1. Signup for a new Account. When signed up, an email needs to be sent to the User with confirmation link.  
    2. Login to an existing and Email confirmed account. User should be able to Login only after E-Mail Confirmation is done.  
    3. Logout from an account.
  2. User can update profile, password of an already existing Account
  3. Able to search for a company to display Company profile & Turn over, CEO, board members, Industry, sector, brief write up, current/latest Stock market price
  4. Whenever user requests charts/data for certain period, the period need to be divided into appropriate intervals(Week or Month or Quarter or Year), to display the chart
  5. View IPOs planned in a Chronological order
  6. When user types in 2 or more characters for a company name or company code, it should display matching company names(using ajax), so that user can select one of
  them, if required
  7. Comparison Charts. It should be possible to perform below comparisons of
    1. a single company over different periods of time  
    2. different companies over a specific period  
    3. a single sector over different periods of time  
    4. different sectors over a specific period  
    5. between a Sector and a company over a specific period of time
  8. Use different colors when multiple Companies/sectors are displayed in a single chart
  and display legend
  9. Should be possible to select between different Chart types.
  10. For a displayed chart, it should be possible to export data and download in Excel
  11. When data does not exist for certain period in between, that need to be appropriately
  indicated in the chart.

## Architecture Diagram

```
        [ Microservice1 ] ----> [         ]
      /                         [ Ocelot  ] --> Angular
( DB ) -- [ Microservice2 ] --> [ API     ]
      \                         [ Gateway ] --> Postman
        [ Microservice3 ] ----> [         ]
```

### Architecture of a Single Microservice

```
              [ Rest Controller ]
            ↙       ↑
[ Model & ]         ↓
[ Entity  ] ←- [ Service ]
[ Classes ]         ↑
            ↖       ↓
              [ Repository ]
                    ↓
                 ( DB )
```

## Tools used

### Editors

- Microsoft Visual Studio
- Visula Studio Code

### Frameworks and Technologies

- .Net Core 3.1
- Microsoft SQL Server
- Entity Framework Core (Code First)
- EPPlus.Core (For Working with MS Excel files)
- JWT Authentication
- Ocelot API Gateway
- Swagger
- CORS

Front End

- Angular CLI 9.1.12
- Angular 9.1.12
- rxjs 6.5.5
- Bootstrap

Other

- IIS
- Postman
- Git

### Languages and Format

- C#
- CSS3
- HTML5
- JSON
- Typescript
