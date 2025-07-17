# MissingTrackApp

This is a Windows Forms-based application developed during an internship at **Haier Europe – Digitalization Department**.

---

## Overview

MissingTrackApp is a missing parts logging and authentication system designed for factory floor personnel and operators. When a serial number and end range are entered, the system automatically generates individual database entries for each serial number within the range, along with user authentication and timestamped operator-linked logging.
---

## Features

- Login with SHA-256 hashed passwords  
- Missing parts entry with barcode and range input  
- Timestamped logging linked to user ID  
- Modular and service-based architecture (Entities, Services, Interfaces)  
- SQL Server integration using ADO.NET  
- Error handling and warning label support

---

## Technologies

- C# (.NET Framework 4.8)  
- WinForms  
- MSSQL (LocalDB / SQLExpress)  
- ADO.NET  
- Git

---

## Database Schema

- **Users**: `Id`, `Username`, `Password`, `Role`  
- **UserInputs**: `InputId`, `ProductBarcode`, `UserId (FK)`, `Timestamp`, `SupplierCode`  
- **Logs**: `LogId`, `UserId (FK)`, `Action`, `Timestamp`

---

## Setup

1. Restore the SQL Server database using the provided `MissingTrack_DB.bak` backup file
2. Update connection string in `App.config`
3. Open and run `MissingTrackApp.sln` in Visual Studio

---

## Author

Developed by **Emre Güner** during 2025 internship at **Haier Europe – Digitalization Department**.

---
