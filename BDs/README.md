# Liste des bases de données utilisées

## Wide World Importers

Cette base de données provient des exemples de Microsoft.

La base de données "Wide World Importers" est décrite dans la documentation :

- [Informations générales](https://learn.microsoft.com/en-us/sql/samples/wide-world-importers-what-is)
- [Description des schémas et des tables](https://learn.microsoft.com/en-us/sql/samples/wide-world-importers-oltp-database-catalog)
- [Génération de données jusqu'à la date courante](https://learn.microsoft.com/en-us/sql/samples/wide-world-importers-generate-data)

Un backup personnalisé est disponible  en [fichier zip ici](https://1drv.ms/u/s!AmZSjqmP5Ux1kaQW7lYjSAsH89pDmw?e=XTOVOG)

<details>
    <summary>Les colonnes des tables sont documentées. Vous trouverez une extraction</summary>
    
| **SchemaName** | **TableName**         | **ColumnName**              | **ExtendedPropertyName** | **ExtendedPropertyValue**                                                                                             |
|----------------|-----------------------|-----------------------------|--------------------------|-----------------------------------------------------------------------------------------------------------------------|
| Application    | Cities                | CityID                      | Description              | Numeric ID used for reference to a city within the database                                                           |
| Application    | Cities                | CityName                    | Description              | Formal name of the city                                                                                               |
| Application    | Cities                | LatestRecordedPopulation    | Description              | Latest available population for the City                                                                              |
| Application    | Cities                | Location                    | Description              | Geographic location of the city                                                                                       |
| Application    | Cities                | StateProvinceID             | Description              | State or province for this city                                                                                       |
| Application    | Countries             | Border                      | Description              | Geographic border of the country as described by the United Nations                                                   |
| Application    | Countries             | Continent                   | Description              | Name of the continent                                                                                                 |
| Application    | Countries             | CountryID                   | Description              | Numeric ID used for reference to a country within the database                                                        |
| Application    | Countries             | CountryName                 | Description              | Name of the country                                                                                                   |
| Application    | Countries             | CountryType                 | Description              | Type of country or administrative region                                                                              |
| Application    | Countries             | FormalName                  | Description              | Full formal name of the country as agreed by United Nations                                                           |
| Application    | Countries             | IsoAlpha3Code               | Description              | 3 letter alphabetic code assigned to the country by ISO                                                               |
| Application    | Countries             | IsoNumericCode              | Description              | Numeric code assigned to the country by ISO                                                                           |
| Application    | Countries             | LatestRecordedPopulation    | Description              | Latest available population for the country                                                                           |
| Application    | Countries             | Region                      | Description              | Name of the region                                                                                                    |
| Application    | Countries             | Subregion                   | Description              | Name of the subregion                                                                                                 |
| Application    | DeliveryMethods       | DeliveryMethodID            | Description              | Numeric ID used for reference to a delivery method within the database                                                |
| Application    | DeliveryMethods       | DeliveryMethodName          | Description              | Full name of methods that can be used for delivery of customer orders                                                 |
| Application    | PaymentMethods        | PaymentMethodID             | Description              | Numeric ID used for reference to a payment type within the database                                                   |
| Application    | PaymentMethods        | PaymentMethodName           | Description              | Full name of ways that customers can make payments or that suppliers can be paid                                      |
| Application    | People                | CustomFields                | Description              | Custom fields for employees and salespeople                                                                           |
| Application    | People                | EmailAddress                | Description              | Email address for this person                                                                                         |
| Application    | People                | FaxNumber                   | Description              | Fax number                                                                                                            |
| Application    | People                | FullName                    | Description              | Full name for this person                                                                                             |
| Application    | People                | HashedPassword              | Description              | Hash of password for users without external logon tokens                                                              |
| Application    | People                | IsEmployee                  | Description              | Is this person an employee?                                                                                           |
| Application    | People                | IsExternalLogonProvider     | Description              | Is logon token provided by an external system?                                                                        |
| Application    | People                | IsPermittedToLogon          | Description              | Is this person permitted to log on?                                                                                   |
| Application    | People                | IsSalesperson               | Description              | Is this person a staff salesperson?                                                                                   |
| Application    | People                | IsSystemUser                | Description              | Is the currently permitted to make online access?                                                                     |
| Application    | People                | LogonName                   | Description              | Person's system logon name                                                                                            |
| Application    | People                | OtherLanguages              | Description              | Other languages spoken (computed column from custom fields)                                                           |
| Application    | People                | PersonID                    | Description              | Numeric ID used for reference to a person within the database                                                         |
| Application    | People                | PhoneNumber                 | Description              | Phone number                                                                                                          |
| Application    | People                | Photo                       | Description              | Photo of this person                                                                                                  |
| Application    | People                | PreferredName               | Description              | Name that this person prefers to be called                                                                            |
| Application    | People                | SearchName                  | Description              | Name to build full text search on (computed column)                                                                   |
| Application    | People                | UserPreferences             | Description              | User preferences related to the website (holds JSON data)                                                             |
| Application    | StateProvinces        | Border                      | Description              | Geographic boundary of the state or province                                                                          |
| Application    | StateProvinces        | CountryID                   | Description              | Country for this StateProvince                                                                                        |
| Application    | StateProvinces        | LatestRecordedPopulation    | Description              | Latest available population for the StateProvince                                                                     |
| Application    | StateProvinces        | SalesTerritory              | Description              | Sales territory for this StateProvince                                                                                |
| Application    | StateProvinces        | StateProvinceCode           | Description              | Common code for this state or province (such as WA - Washington for the USA)                                          |
| Application    | StateProvinces        | StateProvinceID             | Description              | Numeric ID used for reference to a state or province within the database                                              |
| Application    | StateProvinces        | StateProvinceName           | Description              | Formal name of the state or province                                                                                  |
| Application    | SystemParameters      | ApplicationSettings         | Description              | JSON-structured application settings                                                                                  |
| Application    | SystemParameters      | DeliveryAddressLine1        | Description              | First address line for the company                                                                                    |
| Application    | SystemParameters      | DeliveryAddressLine2        | Description              | Second address line for the company                                                                                   |
| Application    | SystemParameters      | DeliveryCityID              | Description              | ID of the city for this address                                                                                       |
| Application    | SystemParameters      | DeliveryLocation            | Description              | Geographic location for the company office                                                                            |
| Application    | SystemParameters      | DeliveryPostalCode          | Description              | Postal code for the company                                                                                           |
| Application    | SystemParameters      | PostalAddressLine1          | Description              | First postal address line for the company                                                                             |
| Application    | SystemParameters      | PostalAddressLine2          | Description              | Second postaladdress line for the company                                                                             |
| Application    | SystemParameters      | PostalCityID                | Description              | ID of the city for this postaladdress                                                                                 |
| Application    | SystemParameters      | PostalPostalCode            | Description              | Postal code for the company when sending via mail                                                                     |
| Application    | SystemParameters      | SystemParameterID           | Description              | Numeric ID used for row holding system parameters                                                                     |
| Application    | TransactionTypes      | TransactionTypeID           | Description              | Numeric ID used for reference to a transaction type within the database                                               |
| Application    | TransactionTypes      | TransactionTypeName         | Description              | Full name of the transaction type                                                                                     |
| Purchasing     | PurchaseOrderLines    | Description                 | Description              | Description of the item to be supplied (Often the stock item name but could be supplier description)                  |
| Purchasing     | PurchaseOrderLines    | ExpectedUnitPricePerOuter   | Description              | The unit price that we expect to be charged                                                                           |
| Purchasing     | PurchaseOrderLines    | IsOrderLineFinalized        | Description              | Is this purchase order line now considered finalized? (Receipted quantities and weights are often not precise)        |
| Purchasing     | PurchaseOrderLines    | LastReceiptDate             | Description              | The last date on which this stock item was received for this purchase order                                           |
| Purchasing     | PurchaseOrderLines    | OrderedOuters               | Description              | Quantity of the stock item that is ordered                                                                            |
| Purchasing     | PurchaseOrderLines    | PackageTypeID               | Description              | Type of package received                                                                                              |
| Purchasing     | PurchaseOrderLines    | PurchaseOrderID             | Description              | Purchase order that this line is associated with                                                                      |
| Purchasing     | PurchaseOrderLines    | PurchaseOrderLineID         | Description              | Numeric ID used for reference to a line on a purchase order within the database                                       |
| Purchasing     | PurchaseOrderLines    | ReceivedOuters              | Description              | Total quantity of the stock item that has been received so far                                                        |
| Purchasing     | PurchaseOrderLines    | StockItemID                 | Description              | Stock item for this purchase order line                                                                               |
| Purchasing     | PurchaseOrders        | Comments                    | Description              | Any comments related this purchase order (comments sent to the supplier)                                              |
| Purchasing     | PurchaseOrders        | ContactPersonID             | Description              | The person who is the primary contact for this purchase order                                                         |
| Purchasing     | PurchaseOrders        | DeliveryMethodID            | Description              | How this purchase order should be delivered                                                                           |
| Purchasing     | PurchaseOrders        | ExpectedDeliveryDate        | Description              | Expected delivery date for this purchase order                                                                        |
| Purchasing     | PurchaseOrders        | InternalComments            | Description              | Any internal comments related this purchase order (comments for internal reference only and not sent to the supplier) |
| Purchasing     | PurchaseOrders        | IsOrderFinalized            | Description              | Is this purchase order now considered finalized?                                                                      |
| Purchasing     | PurchaseOrders        | OrderDate                   | Description              | Date that this purchase order was raised                                                                              |
| Purchasing     | PurchaseOrders        | PurchaseOrderID             | Description              | Numeric ID used for reference to a purchase order within the database                                                 |
| Purchasing     | PurchaseOrders        | SupplierID                  | Description              | Supplier for this purchase order                                                                                      |
| Purchasing     | PurchaseOrders        | SupplierReference           | Description              | Supplier reference for our organization (might be our account number at the supplier)                                 |
| Purchasing     | SupplierCategories    | SupplierCategoryID          | Description              | Numeric ID used for reference to a supplier category within the database                                              |
| Purchasing     | SupplierCategories    | SupplierCategoryName        | Description              | Full name of the category that suppliers can be assigned to                                                           |
| Purchasing     | Suppliers             | AlternateContactPersonID    | Description              | Alternate contact                                                                                                     |
| Purchasing     | Suppliers             | BankAccountBranch           | Description              | Supplier's bank branch                                                                                                |
| Purchasing     | Suppliers             | BankAccountCode             | Description              | Supplier's bank account code (usually a numeric reference for the bank branch)                                        |
| Purchasing     | Suppliers             | BankAccountName             | Description              | Supplier's bank account name (ie name on the account)                                                                 |
| Purchasing     | Suppliers             | BankAccountNumber           | Description              | Supplier's bank account number                                                                                        |
| Purchasing     | Suppliers             | BankInternationalCode       | Description              | Supplier's bank's international code (such as a SWIFT code)                                                           |
| Purchasing     | Suppliers             | DeliveryAddressLine1        | Description              | First delivery address line for the supplier                                                                          |
| Purchasing     | Suppliers             | DeliveryAddressLine2        | Description              | Second delivery address line for the supplier                                                                         |
| Purchasing     | Suppliers             | DeliveryCityID              | Description              | ID of the delivery city for this address                                                                              |
| Purchasing     | Suppliers             | DeliveryLocation            | Description              | Geographic location for the supplier's office/warehouse                                                               |
| Purchasing     | Suppliers             | DeliveryMethodID            | Description              | Standard delivery method for stock items received from this supplier                                                  |
| Purchasing     | Suppliers             | DeliveryPostalCode          | Description              | Delivery postal code for the supplier                                                                                 |
| Purchasing     | Suppliers             | FaxNumber                   | Description              | Fax number                                                                                                            |
| Purchasing     | Suppliers             | InternalComments            | Description              | Internal comments (not exposed outside organization)                                                                  |
| Purchasing     | Suppliers             | PaymentDays                 | Description              | Number of days for payment of an invoice (ie payment terms)                                                           |
| Purchasing     | Suppliers             | PhoneNumber                 | Description              | Phone number                                                                                                          |
| Purchasing     | Suppliers             | PostalAddressLine1          | Description              | First postal address line for the supplier                                                                            |
| Purchasing     | Suppliers             | PostalAddressLine2          | Description              | Second postal address line for the supplier                                                                           |
| Purchasing     | Suppliers             | PostalCityID                | Description              | ID of the mailing city for this address                                                                               |
| Purchasing     | Suppliers             | PostalPostalCode            | Description              | Postal code for the supplier when sending by mail                                                                     |
| Purchasing     | Suppliers             | PrimaryContactPersonID      | Description              | Primary contact                                                                                                       |
| Purchasing     | Suppliers             | SupplierCategoryID          | Description              | Supplier's category                                                                                                   |
| Purchasing     | Suppliers             | SupplierID                  | Description              | Numeric ID used for reference to a supplier within the database                                                       |
| Purchasing     | Suppliers             | SupplierName                | Description              | Supplier's full name (usually a trading name)                                                                         |
| Purchasing     | Suppliers             | SupplierReference           | Description              | Supplier reference for our organization (might be our account number at the supplier)                                 |
| Purchasing     | Suppliers             | WebsiteURL                  | Description              | URL for the website for this supplier                                                                                 |
| Purchasing     | SupplierTransactions  | AmountExcludingTax          | Description              | Transaction amount (excluding tax)                                                                                    |
| Purchasing     | SupplierTransactions  | FinalizationDate            | Description              | Date that this transaction was finalized (if it has been)                                                             |
| Purchasing     | SupplierTransactions  | IsFinalized                 | Description              | Is this transaction finalized (invoices, credits and payments have been matched)                                      |
| Purchasing     | SupplierTransactions  | OutstandingBalance          | Description              | Amount still outstanding for this transaction                                                                         |
| Purchasing     | SupplierTransactions  | PaymentMethodID             | Description              | ID of a payment method (for transactions involving payments)                                                          |
| Purchasing     | SupplierTransactions  | PurchaseOrderID             | Description              | ID of an purchase order (for transactions associated with a purchase order)                                           |
| Purchasing     | SupplierTransactions  | SupplierID                  | Description              | Supplier for this transaction                                                                                         |
| Purchasing     | SupplierTransactions  | SupplierInvoiceNumber       | Description              | Invoice number for an invoice received from the supplier                                                              |
| Purchasing     | SupplierTransactions  | SupplierTransactionID       | Description              | Numeric ID used to refer to a supplier transaction within the database                                                |
| Purchasing     | SupplierTransactions  | TaxAmount                   | Description              | Tax amount calculated                                                                                                 |
| Purchasing     | SupplierTransactions  | TransactionAmount           | Description              | Transaction amount (including tax)                                                                                    |
| Purchasing     | SupplierTransactions  | TransactionDate             | Description              | Date for the transaction                                                                                              |
| Purchasing     | SupplierTransactions  | TransactionTypeID           | Description              | Type of transaction                                                                                                   |
| Sales          | BuyingGroups          | BuyingGroupID               | Description              | Numeric ID used for reference to a buying group within the database                                                   |
| Sales          | BuyingGroups          | BuyingGroupName             | Description              | Full name of a buying group that customers can be members of                                                          |
| Sales          | CustomerCategories    | CustomerCategoryID          | Description              | Numeric ID used for reference to a customer category within the database                                              |
| Sales          | CustomerCategories    | CustomerCategoryName        | Description              | Full name of the category that customers can be assigned to                                                           |
| Sales          | Customers             | AccountOpenedDate           | Description              | Date this customer account was opened                                                                                 |
| Sales          | Customers             | AlternateContactPersonID    | Description              | Alternate contact                                                                                                     |
| Sales          | Customers             | BillToCustomerID            | Description              | Customer that this is billed to (usually the same customer but can be another parent company)                         |
| Sales          | Customers             | BuyingGroupID               | Description              | Customer's buying group (optional)                                                                                    |
| Sales          | Customers             | CreditLimit                 | Description              | Credit limit for this customer (NULL if unlimited)                                                                    |
| Sales          | Customers             | CustomerCategoryID          | Description              | Customer's category                                                                                                   |
| Sales          | Customers             | CustomerID                  | Description              | Numeric ID used for reference to a customer within the database                                                       |
| Sales          | Customers             | CustomerName                | Description              | Customer's full name (usually a trading name)                                                                         |
| Sales          | Customers             | DeliveryAddressLine1        | Description              | First delivery address line for the customer                                                                          |
| Sales          | Customers             | DeliveryAddressLine2        | Description              | Second delivery address line for the customer                                                                         |
| Sales          | Customers             | DeliveryCityID              | Description              | ID of the delivery city for this address                                                                              |
| Sales          | Customers             | DeliveryLocation            | Description              | Geographic location for the customer's office/warehouse                                                               |
| Sales          | Customers             | DeliveryMethodID            | Description              | Standard delivery method for stock items sent to this customer                                                        |
| Sales          | Customers             | DeliveryPostalCode          | Description              | Delivery postal code for the customer                                                                                 |
| Sales          | Customers             | DeliveryRun                 | Description              | Normal delivery run for this customer                                                                                 |
| Sales          | Customers             | FaxNumber                   | Description              | Fax number                                                                                                            |
| Sales          | Customers             | IsOnCreditHold              | Description              | Is this customer on credit hold? (Prevents further deliveries to this customer)                                       |
| Sales          | Customers             | IsStatementSent             | Description              | Is a statement sent to this customer? (Or do they just pay on each invoice?)                                          |
| Sales          | Customers             | PaymentDays                 | Description              | Number of days for payment of an invoice (ie payment terms)                                                           |
| Sales          | Customers             | PhoneNumber                 | Description              | Phone number                                                                                                          |
| Sales          | Customers             | PostalAddressLine1          | Description              | First postal address line for the customer                                                                            |
| Sales          | Customers             | PostalAddressLine2          | Description              | Second postal address line for the customer                                                                           |
| Sales          | Customers             | PostalCityID                | Description              | ID of the postal city for this address                                                                                |
| Sales          | Customers             | PostalPostalCode            | Description              | Postal code for the customer when sending by mail                                                                     |
| Sales          | Customers             | PrimaryContactPersonID      | Description              | Primary contact                                                                                                       |
| Sales          | Customers             | RunPosition                 | Description              | Normal position in the delivery run for this customer                                                                 |
| Sales          | Customers             | StandardDiscountPercentage  | Description              | Standard discount offered to this customer                                                                            |
| Sales          | Customers             | WebsiteURL                  | Description              | URL for the website for this customer                                                                                 |
| Sales          | CustomerTransactions  | AmountExcludingTax          | Description              | Transaction amount (excluding tax)                                                                                    |
| Sales          | CustomerTransactions  | CustomerID                  | Description              | Customer for this transaction                                                                                         |
| Sales          | CustomerTransactions  | CustomerTransactionID       | Description              | Numeric ID used to refer to a customer transaction within the database                                                |
| Sales          | CustomerTransactions  | FinalizationDate            | Description              | Date that this transaction was finalized (if it has been)                                                             |
| Sales          | CustomerTransactions  | InvoiceID                   | Description              | ID of an invoice (for transactions associated with an invoice)                                                        |
| Sales          | CustomerTransactions  | IsFinalized                 | Description              | Is this transaction finalized (invoices, credits and payments have been matched)                                      |
| Sales          | CustomerTransactions  | OutstandingBalance          | Description              | Amount still outstanding for this transaction                                                                         |
| Sales          | CustomerTransactions  | PaymentMethodID             | Description              | ID of a payment method (for transactions involving payments)                                                          |
| Sales          | CustomerTransactions  | TaxAmount                   | Description              | Tax amount calculated                                                                                                 |
| Sales          | CustomerTransactions  | TransactionAmount           | Description              | Transaction amount (including tax)                                                                                    |
| Sales          | CustomerTransactions  | TransactionDate             | Description              | Date for the transaction                                                                                              |
| Sales          | CustomerTransactions  | TransactionTypeID           | Description              | Type of transaction                                                                                                   |
| Sales          | InvoiceLines          | Description                 | Description              | Description of the item supplied (Usually the stock item name but can be overridden)                                  |
| Sales          | InvoiceLines          | ExtendedPrice               | Description              | Extended line price charged                                                                                           |
| Sales          | InvoiceLines          | InvoiceID                   | Description              | Invoice that this line is associated with                                                                             |
| Sales          | InvoiceLines          | InvoiceLineID               | Description              | Numeric ID used for reference to a line on an invoice within the database                                             |
| Sales          | InvoiceLines          | LineProfit                  | Description              | Profit made on this line item at current cost price                                                                   |
| Sales          | InvoiceLines          | PackageTypeID               | Description              | Type of package supplied                                                                                              |
| Sales          | InvoiceLines          | Quantity                    | Description              | Quantity supplied                                                                                                     |
| Sales          | InvoiceLines          | StockItemID                 | Description              | Stock item for this invoice line                                                                                      |
| Sales          | InvoiceLines          | TaxAmount                   | Description              | Tax amount calculated                                                                                                 |
| Sales          | InvoiceLines          | TaxRate                     | Description              | Tax rate to be applied                                                                                                |
| Sales          | InvoiceLines          | UnitPrice                   | Description              | Unit price charged                                                                                                    |
| Sales          | Invoices              | AccountsPersonID            | Description              | Customer accounts contact for this invoice                                                                            |
| Sales          | Invoices              | BillToCustomerID            | Description              | Bill to customer for this invoice (invoices might be billed to a head office)                                         |
| Sales          | Invoices              | Comments                    | Description              | Any comments related to this invoice (sent to customer)                                                               |
| Sales          | Invoices              | ConfirmedDeliveryTime       | Description              | Confirmed delivery date and time promoted from JSON delivery data                                                     |
| Sales          | Invoices              | ConfirmedReceivedBy         | Description              | Confirmed receiver promoted from JSON delivery data                                                                   |
| Sales          | Invoices              | ContactPersonID             | Description              | Customer contact for this invoice                                                                                     |
| Sales          | Invoices              | CreditNoteReason            | Description              | Reason that this credit note needed to be generated (if applicable)                                                   |
| Sales          | Invoices              | CustomerID                  | Description              | Customer for this invoice                                                                                             |
| Sales          | Invoices              | CustomerPurchaseOrderNumber | Description              | Purchase Order Number received from customer                                                                          |
| Sales          | Invoices              | DeliveryInstructions        | Description              | Any comments related to delivery (sent to customer)                                                                   |
| Sales          | Invoices              | DeliveryMethodID            | Description              | How these stock items are beign delivered                                                                             |
| Sales          | Invoices              | DeliveryRun                 | Description              | Delivery run for this shipment                                                                                        |
| Sales          | Invoices              | InternalComments            | Description              | Any internal comments related to this invoice (not sent to the customer)                                              |
| Sales          | Invoices              | InvoiceDate                 | Description              | Date that this invoice was raised                                                                                     |
| Sales          | Invoices              | InvoiceID                   | Description              | Numeric ID used for reference to an invoice within the database                                                       |
| Sales          | Invoices              | IsCreditNote                | Description              | Is this a credit note (rather than an invoice)                                                                        |
| Sales          | Invoices              | OrderID                     | Description              | Sales order (if any) for this invoice                                                                                 |
| Sales          | Invoices              | PackedByPersonID            | Description              | Person who packed this shipment (or checked the packing)                                                              |
| Sales          | Invoices              | ReturnedDeliveryData        | Description              | JSON-structured data returned from delivery devices for deliveries made directly by the organization                  |
| Sales          | Invoices              | RunPosition                 | Description              | Position in the delivery run for this shipment                                                                        |
| Sales          | Invoices              | SalespersonPersonID         | Description              | Salesperson for this invoice                                                                                          |
| Sales          | Invoices              | TotalChillerItems           | Description              | Total number of chiller packages (information for the delivery driver)                                                |
| Sales          | Invoices              | TotalDryItems               | Description              | Total number of dry packages (information for the delivery driver)                                                    |
| Sales          | OrderLines            | Description                 | Description              | Description of the item supplied (Usually the stock item name but can be overridden)                                  |
| Sales          | OrderLines            | OrderID                     | Description              | Order that this line is associated with                                                                               |
| Sales          | OrderLines            | OrderLineID                 | Description              | Numeric ID used for reference to a line on an Order within the database                                               |
| Sales          | OrderLines            | PackageTypeID               | Description              | Type of package to be supplied                                                                                        |
| Sales          | OrderLines            | PickedQuantity              | Description              | Quantity picked from stock                                                                                            |
| Sales          | OrderLines            | PickingCompletedWhen        | Description              | When was picking of this line completed?                                                                              |
| Sales          | OrderLines            | Quantity                    | Description              | Quantity to be supplied                                                                                               |
| Sales          | OrderLines            | StockItemID                 | Description              | Stock item for this order line (FK not indexed as separate index exists)                                              |
| Sales          | OrderLines            | TaxRate                     | Description              | Tax rate to be applied                                                                                                |
| Sales          | OrderLines            | UnitPrice                   | Description              | Unit price to be charged                                                                                              |
| Sales          | Orders                | BackorderOrderID            | Description              | If this order is a backorder, this column holds the original order number                                             |
| Sales          | Orders                | Comments                    | Description              | Any comments related to this order (sent to customer)                                                                 |
| Sales          | Orders                | ContactPersonID             | Description              | Customer contact for this order                                                                                       |
| Sales          | Orders                | CustomerID                  | Description              | Customer for this order                                                                                               |
| Sales          | Orders                | CustomerPurchaseOrderNumber | Description              | Purchase Order Number received from customer                                                                          |
| Sales          | Orders                | DeliveryInstructions        | Description              | Any comments related to order delivery (sent to customer)                                                             |
| Sales          | Orders                | ExpectedDeliveryDate        | Description              | Expected delivery date                                                                                                |
| Sales          | Orders                | InternalComments            | Description              | Any internal comments related to this order (not sent to the customer)                                                |
| Sales          | Orders                | IsUndersupplyBackordered    | Description              | If items cannot be supplied are they backordered?                                                                     |
| Sales          | Orders                | OrderDate                   | Description              | Date that this order was raised                                                                                       |
| Sales          | Orders                | OrderID                     | Description              | Numeric ID used for reference to an order within the database                                                         |
| Sales          | Orders                | PickedByPersonID            | Description              | Person who picked this shipment                                                                                       |
| Sales          | Orders                | PickingCompletedWhen        | Description              | When was picking of the entire order completed?                                                                       |
| Sales          | Orders                | SalespersonPersonID         | Description              | Salesperson for this order                                                                                            |
| Sales          | SpecialDeals          | BuyingGroupID               | Description              | ID of the buying group that the special pricing applies to (optional)                                                 |
| Sales          | SpecialDeals          | CustomerCategoryID          | Description              | ID of the customer category that the special pricing applies to (optional)                                            |
| Sales          | SpecialDeals          | CustomerID                  | Description              | ID of the customer that the special pricing applies to (if NULL then all customers)                                   |
| Sales          | SpecialDeals          | DealDescription             | Description              | Description of the special deal                                                                                       |
| Sales          | SpecialDeals          | DiscountAmount              | Description              | Discount per unit to be applied to sale price (optional)                                                              |
| Sales          | SpecialDeals          | DiscountPercentage          | Description              | Discount percentage per unit to be applied to sale price (optional)                                                   |
| Sales          | SpecialDeals          | EndDate                     | Description              | Date that the special pricing ends on                                                                                 |
| Sales          | SpecialDeals          | SpecialDealID               | Description              | ID (sequence based) for a special deal                                                                                |
| Sales          | SpecialDeals          | StartDate                   | Description              | Date that the special pricing starts from                                                                             |
| Sales          | SpecialDeals          | StockGroupID                | Description              | ID of the stock group that the special pricing applies to (optional)                                                  |
| Sales          | SpecialDeals          | StockItemID                 | Description              | Stock item that the deal applies to (if NULL, then only discounts are permitted not unit prices)                      |
| Sales          | SpecialDeals          | UnitPrice                   | Description              | Special price per unit to be applied instead of sale price (optional)                                                 |
| Warehouse      | Colors                | ColorID                     | Description              | Numeric ID used for reference to a color within the database                                                          |
| Warehouse      | Colors                | ColorName                   | Description              | Full name of a color that can be used to describe stock items                                                         |
| Warehouse      | PackageTypes          | PackageTypeID               | Description              | Numeric ID used for reference to a package type within the database                                                   |
| Warehouse      | PackageTypes          | PackageTypeName             | Description              | Full name of package types that stock items can be purchased in or sold in                                            |
| Warehouse      | StockGroups           | StockGroupID                | Description              | Numeric ID used for reference to a stock group within the database                                                    |
| Warehouse      | StockGroups           | StockGroupName              | Description              | Full name of groups used to categorize stock items                                                                    |
| Warehouse      | StockItemHoldings     | BinLocation                 | Description              | Bin location (ie location of this stock item within the depot)                                                        |
| Warehouse      | StockItemHoldings     | LastCostPrice               | Description              | Unit cost price the last time this stock item was purchased                                                           |
| Warehouse      | StockItemHoldings     | LastStocktakeQuantity       | Description              | Quantity at last stocktake (if tracked)                                                                               |
| Warehouse      | StockItemHoldings     | QuantityOnHand              | Description              | Quantity currently on hand (if tracked)                                                                               |
| Warehouse      | StockItemHoldings     | ReorderLevel                | Description              | Quantity below which reordering should take place                                                                     |
| Warehouse      | StockItemHoldings     | StockItemID                 | Description              | ID of the stock item that this holding relates to (this table holds non-temporal columns for stock)                   |
| Warehouse      | StockItemHoldings     | TargetStockLevel            | Description              | Typical quantity ordered                                                                                              |
| Warehouse      | StockItems            | Barcode                     | Description              | Barcode for this stock item                                                                                           |
| Warehouse      | StockItems            | Brand                       | Description              | Brand for the stock item (if the item is branded)                                                                     |
| Warehouse      | StockItems            | ColorID                     | Description              | Color (optional) for this stock item                                                                                  |
| Warehouse      | StockItems            | CustomFields                | Description              | Custom fields added by system users                                                                                   |
| Warehouse      | StockItems            | InternalComments            | Description              | Internal comments (not exposed outside organization)                                                                  |
| Warehouse      | StockItems            | IsChillerStock              | Description              | Does this stock item need to be in a chiller?                                                                         |
| Warehouse      | StockItems            | LeadTimeDays                | Description              | Number of days typically taken from order to receipt of this stock item                                               |
| Warehouse      | StockItems            | MarketingComments           | Description              | Marketing comments for this stock item (shared outside the organization)                                              |
| Warehouse      | StockItems            | OuterPackageID              | Description              | Usual package for selling outers of this stock item (ie cartons, boxes, etc.)                                         |
| Warehouse      | StockItems            | Photo                       | Description              | Photo of the product                                                                                                  |
| Warehouse      | StockItems            | QuantityPerOuter            | Description              | Quantity of the stock item in an outer package                                                                        |
| Warehouse      | StockItems            | RecommendedRetailPrice      | Description              | Recommended retail price for this stock item                                                                          |
| Warehouse      | StockItems            | SearchDetails               | Description              | Combination of columns used by full text search                                                                       |
| Warehouse      | StockItems            | Size                        | Description              | Size of this item (eg: 100mm)                                                                                         |
| Warehouse      | StockItems            | StockItemID                 | Description              | Numeric ID used for reference to a stock item within the database                                                     |
| Warehouse      | StockItems            | StockItemName               | Description              | Full name of a stock item (but not a full description)                                                                |
| Warehouse      | StockItems            | SupplierID                  | Description              | Usual supplier for this stock item                                                                                    |
| Warehouse      | StockItems            | Tags                        | Description              | Advertising tags associated with this stock item (JSON array retrieved from CustomFields)                             |
| Warehouse      | StockItems            | TaxRate                     | Description              | Tax rate to be applied                                                                                                |
| Warehouse      | StockItems            | TypicalWeightPerUnit        | Description              | Typical weight for one unit of this product (packaged)                                                                |
| Warehouse      | StockItems            | UnitPackageID               | Description              | Usual package for selling units of this stock item                                                                    |
| Warehouse      | StockItems            | UnitPrice                   | Description              | Selling price (ex-tax) for one unit of this product                                                                   |
| Warehouse      | StockItemStockGroups  | StockGroupID                | Description              | StockGroup assigned to this stock item (FK indexed via unique constraint)                                             |
| Warehouse      | StockItemStockGroups  | StockItemID                 | Description              | Stock item assigned to this stock group (FK indexed via unique constraint)                                            |
| Warehouse      | StockItemStockGroups  | StockItemStockGroupID       | Description              | Internal reference for this linking row                                                                               |
| Warehouse      | StockItemTransactions | CustomerID                  | Description              | Customer for this transaction (if applicable)                                                                         |
| Warehouse      | StockItemTransactions | InvoiceID                   | Description              | ID of an invoice (for transactions associated with an invoice)                                                        |
| Warehouse      | StockItemTransactions | PurchaseOrderID             | Description              | ID of an purchase order (for transactions associated with a purchase order)                                           |
| Warehouse      | StockItemTransactions | Quantity                    | Description              | Quantity of stock movement (positive is incoming stock, negative is outgoing)                                         |
| Warehouse      | StockItemTransactions | StockItemID                 | Description              | StockItem for this transaction                                                                                        |
| Warehouse      | StockItemTransactions | StockItemTransactionID      | Description              | Numeric ID used to refer to a stock item transaction within the database                                              |
| Warehouse      | StockItemTransactions | SupplierID                  | Description              | Supplier for this stock transaction (if applicable)                                                                   |
| Warehouse      | StockItemTransactions | TransactionOccurredWhen     | Description              | Date and time when the transaction occurred                                                                           |
| Warehouse      | StockItemTransactions | TransactionTypeID           | Description              | Type of transaction                                                                                                   |

La liste a été obtenue en utilisant la requête suivante ([adaptée du site](https://www.mssqltips.com/sqlservertip/5384/working-with-sql-server-extended-properties/)) :

```sql
SELECT
   SCHEMA_NAME(tbl.schema_id) AS SchemaName
   , tbl.name AS TableName
   , clmns.name AS ColumnName
   , p.name AS ExtendedPropertyName
   , CAST(p.value AS sql_variant) AS ExtendedPropertyValue
FROM
   sys.tables AS tbl
   INNER JOIN sys.all_columns AS clmns ON clmns.object_id = tbl.object_id
   INNER JOIN sys.extended_properties AS p ON 
              p.major_id = tbl.object_id 
          AND p.minor_id = clmns.column_id 
          AND p.class = 1
WHERE p.name = 'Description'
ORDER BY SchemaName, TableName, ColumnName
```
