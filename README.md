<div align="center">

# 🏋️‍♂️ Titan Gym Management System

**An academic desktop application built in C# with an 3-Tier architecture to streamline gym operations, memberships, and financial tracking.**

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](#)
[![.NET Framework 4.8](https://img.shields.io/badge/.NET_Framework_4.8-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](#)
[![SQL Server 2022](https://img.shields.io/badge/SQL_Server_2022-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](#)
[![Guna UI 2.0.4.8](https://img.shields.io/badge/UI-Guna2_WinForms-0078D7?style=for-the-badge)](#)
[![Database](https://img.shields.io/badge/Database-SQL%20Server-red?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](#) [![Data Access](https://img.shields.io/badge/Data%20Access-ADO.NET-blue?style=for-the-badge&logo=.net&logoColor=white)](#)
[![Architecture](https://img.shields.io/badge/Architecture-3--Tier-brightgreen?style=for-the-badge)](#)

<img src="https://placehold.co/1000x300/1e1e1e/4caf50?text=Titan+Gym+Management+System&font=montserrat" alt="Titan Gym Cover" width="100%">

</div>

---


## 🖼️ Project Preview

> **Note:** The application features a modern, dark-themed responsive user interface built using the Guna UI framework for an exceptional user experience.

* **📸 Project Screenshots:** All application screenshots, UI designs, and interface previews are safely stored and available inside the dedicated project folder (`/Screenshots` or the attached assets folder) located within the repository. Feel free to browse them to explore the system's look and feel!** 
---

## 🎯 About The Project

**Titan Gym Management System** is a robust, fully functional desktop solution engineered to eliminate the manual overhead of managing fitness centers. Developed entirely in **C#**, the project strictly implements a clean **N-Tier Architecture**, effectively decoupling the User Interface (UI), Business Logic Layer (BLL), and Data Access Layer (DAL). This modular approach guarantees high maintainability, ironclad database security, and a frictionless experience for gym administrators.

---

## ✨ Key Features

### 🔐 Authentication & Security
- **Secure Login** with username/password authentication
- **Account Status Management** (Active/Inactive accounts)
- **"Remember Me"** functionality for quick access
- **Role-Based Access Control (RBAC)** with granular permissions
- **Permission System** using bitwise operations (Dashboard, People, Members, Trainers, Plans, Subscriptions, Payments, Trainer Assignments, Users)

### 👥 People Management
- **Complete CRUD operations** for individuals
- **Personal Details** (First, Second, Third, Last Name)
- **Gender Selection** (Male/Female)
- **Contact Information** (Phone, Email, Address)
- **Date of Birth** tracking
- **Profile Image Management** with upload, delete, and auto-resizing
- **Search & Filter** by Person ID

### 🏋️ Member Management
- **Member Registration** linked to existing people
- **Emergency Contact Details** (Name & Phone)
- **Membership Statuses**:
  - Active
  - Inactive
  - Suspended
  - Expired
  - Pending
- **Active Member Check** before creating new memberships
- **Pending Expiry Monitoring** (configurable days)

### 📋 Membership Plans
- **Tiered Plans** (Basic, Silver, Gold, Platinum, VIP)
- **Plan Management** (Create, Update, Delete)
- **Duration Setting** in months
- **Monthly Price** configuration
- **Availability Status** (Available/Unavailable)
- **Duplicate Name Prevention**
- **Plan Status Colors** in DataGrid

### 📅 Subscriptions
- **Assign Members to Plans** with automatic fee calculation
- **Start/End Date Management** with validation
- **Active Subscription Check** (prevents duplicate active subscriptions)
- **Manual Expiry** functionality
- **Subscription Status Tracking** (Active, Expired, Cancelled, etc.)
- **Auto-expiry** on end date

### 💳 Payment Processing
- **Payment Recording** linked to subscriptions
- **Multiple Payment Methods** (Cash, Credit Card, Bank Transfer, etc.)
- **Payment Status Tracking** (Paid, Pending, Failed)
- **Amount Validation** and formatting as currency
- **Optional Notes** for transactions
- **Revenue Calculation** across all payments

### 👨‍🏫 Trainer Management
- **Trainer Registration** linked to existing people
- **Specialization Tracking**
- **Employment Status Management**
- **Member Assignment Tracking** (total members per trainer)
- **Hire Date** recording
- **Salary Management**

### 👤 User Administration
- **User Creation** linked to existing people
- **Role Assignment** (Admin, Manager, Receptionist, Trainer)
- **Account Status Management** (Active/Inactive)
- **Username Uniqueness Validation**
- **Password Management**
- **Creation Date Tracking**

### 📊 Dashboard Analytics
- **Key Metrics Cards**:
  - Total Members (Active)
  - Total Subscriptions
  - Total Revenue
  - Total Trainers
  - Total Member Assignments
  - Total Active Users
- **Recent Subscriptions DataGrid**
- **Real-time Updates** on data changes
- **Data Binding** for automatic refresh

### 🎨 Modern UI/UX
- **Dark Theme** with cyan accents (#00E5FF)
- **Responsive Layout** with Guna UI2 controls
- **Interactive DataGrids** with sorting and filtering
- **Context Menus** for quick actions
- **Form Validation** with error providers
- **Toast Notifications** (via MessageBox)
- **Intuitive Navigation** with left sidebar

---

## 🛠️ Tech Stack & Dependencies

| Category | Technology / Library | Version | Description |
| :--- | :--- | :--- | :--- |
| **Language** | C# | 8.0+ | Primary backend and logic language. |
| **Framework** | .NET Framework | v4.7.2 | Target runtime environment for WinForms. |
| **Database** | Microsoft SQL Server | 2019 / 2022 | Relational database management system. |
| **Data Access** | ADO.NET | `System.Data.SqlClient` | Direct database communication layer. |
| **UI Framework** | WinForms | Native | Core graphical user interface subsystem. |
| **UI/UX Library** | Guna.UI2.WinForms | v2.0.4.6 | Advanced custom controls and modern styling. |

---

## ⚙️ Installation & Setup Guide

Follow these exact steps to configure and launch the system in your local development environment.

> [!IMPORTANT]
> **1️⃣ Install .NET Framework 4.7.2**
> The target framework is required to compile and execute the solution.
> * Download the `.NET Framework 4.7.2 Developer Pack`.
> * 🔗 [Official Microsoft Download Page](https://dotnet.microsoft.com/download/dotnet-framework/net472)

> [!IMPORTANT]
> **2️⃣ Restore the SQL Server Database**
> The application requires the pre-configured relational schema and stored procedures.
> 1. Open **SQL Server Management Studio (SSMS)**.
> 2. Right-click on `Databases` in the Object Explorer $\rightarrow$ Select **Restore Database...**
> 3. Choose **Device** $\rightarrow$ Click `...` $\rightarrow$ Add the provided backup file.
> 4. **Backup File Name:** `TitanGym_DB_Master.bak`
> 5. Click **OK** to execute the database restoration.

> [!IMPORTANT]
> **3️⃣ Install Modern UI Dependencies**
> The Guna UI package must be restored via NuGet to render the custom controls.
> 1. Open `TitanGym_Solution.sln` in **Visual Studio 2022**.
> 2. Navigate to `Tools` $\rightarrow$ `NuGet Package Manager` $\rightarrow$ `Manage NuGet Packages for Solution`.
> 3. Search for **Guna.UI2.WinForms**.
> 4. Select the `TitanGym_PresentationLayer` project and install version `2.0.4.6`.

### 4️⃣ Database Connection Configuration
Navigate to the `App.config` file located inside the Presentation Layer project. Update the connection string to point to your local SQL Server instance:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<startup>
		<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.8" />

	</startup>

	<connectionStrings>
		<add name="TitanGymConnectionString" connectionString="Server=.;Database=GYM_ManagementSystem;User Id=sa;Password=sa123456;"/>
	</connectionStrings>

</configuration>
```

Build and execute the solution:
```bash
# Clean previous builds
dotnet clean

# Build the entire solution
dotnet build

# Run the UI Presentation Layer
dotnet run --project TitanGym_PresentationLayer\TitanGym_PresentationLayer.csproj
```

---

## ⚙️ Configuration & Storage Paths

The application relies on specific local storage paths for handling user profile images and the "Remember Me" session feature. **Please ensure these directories/files exist or update them according to your environment:**

* **Images Directory (`DirectoryPath`):** 
  * Default Path: `C:\ImagesTitanGym`
  * **Purpose:** Stores profile pictures for members and trainers.
  * **Note:** Ensure the application has Read/Write permissions to this directory, or update the path in `Utility.cs` if you prefer storing them elsewhere (e.g., inside the application folder or another drive).

* **Remember Me File (`FileRemPath`):** 
  * Default Path: `F:\RememberMeTitanGym.txt`
  * **Purpose:** Saves encrypted login tokens for the "Remember Me" functionality.
  * **Note:** If the `F:` drive is not available on the target machine, make sure to update this path in `Utility.cs` to a valid drive (e.g., `C:\TitanGym\RememberMeTitanGym.txt`) to prevent runtime exceptions.

 ---
## 📂 Project Architecture (3-Tier)

The system is rigorously architected using a 3-Tier design pattern, ensuring code reusability, tight security, and absolute separation of concerns:
```text
TitanGym/
├── TitanGym_BusinessLayer/               # Business Logic Layer
│   ├── Account StatusesBL/               # Account status business logic
│   │   └── AccountStatusBL.cs
│   ├── Availability StatusesBL/          # Availability status business logic
│   │   └── AvailabilityStatusBL.cs
│   ├── Employment StatusesBL/            # Employment status business logic
│   │   └── EmploymentStatusesBL.cs
│   ├── MemberBL/                         # Member business logic
│   │   └── MemberBL.cs
│   ├── MembershipsBL/                    # Membership plan business logic
│   │   └── MembershipBL.cs
│   ├── Payment MethodsBL/                # Payment method business logic
│   │   └── PaymentMethodBL.cs
│   ├── Payment StatusesBL/               # Payment status business logic
│   │   └── PaymentStatusesBL.cs
│   ├── PaymentsBL/                       # Payment business logic
│   │   └── PaymentsBL.cs
│   ├── PeopleBL/                         # People business logic
│   │   └── PeopleBL.cs
│   ├── RolesBL/                          # Role business logic
│   │   └── RoleBL.cs
│   ├── SpecializationBL/                 # Specialization business logic
│   │   └── SpecializationBL.cs
│   ├── SubscriptionBL/                   # Subscription business logic
│   │   └── SubscriptionBL.cs
│   ├── Subscription StatusesBL/          # Subscription status business logic
│   │   └── SubscriptionStatusBL.cs
│   ├── Trainer AssignmentsBL/            # Trainer assignment business logic
│   │   └── TrainerAssignmentsBL.cs
│   ├── TrainersBL/                       # Trainer business logic
│   │   └── TrainerBL.cs
│   └── UsersBL/                          # User business logic
│       └── UserBL.cs
│
├── TitanGym_DataAccessLayer/             # Data Access Layer
│   ├── Account Statuses/                 # Account status data access
│   │   └── AccountStatusesDALQueries.cs
│   ├── Availability Statuses/            # Availability status data access
│   │   └── AvailabilityStatusesDALQueries.cs
│   ├── Employment Statuses/              # Employment status data access
│   │   └── EmploymentStatusesDALQueries.cs
│   ├── Helper/                           # Database helper utilities
│   │   └── HelperDAL.cs
│   ├── Members/                          # Member data access
│   │   ├── MemberDALCommands.cs
│   │   └── MemberDALQueries.cs
│   ├── Memberships/                      # Membership plan data access
│   │   ├── MembershipsDALCommands.cs
│   │   └── MembershipsDALQueries.cs
│   ├── Payment Methods/                  # Payment method data access
│   │   └── PaymentMethodDALQueries.cs
│   ├── Payment Statuses/                 # Payment status data access
│   │   └── PaymentStatusDALQueries.cs
│   ├── Payments/                         # Payment data access
│   │   ├── PaymentsDALCommands.cs
│   │   └── PaymentsDALQueries.cs
│   ├── People/                           # People data access
│   │   ├── PeopleDALCommands.cs
│   │   └── PeopleDALQueries.cs
│   ├── Roles/                            # Role data access
│   │   └── RolesDALQueries.cs
│   ├── Specialization/                   # Specialization data access
│   │   └── SpecializationDALQueries.cs
│   ├── Subscription Statuses/            # Subscription status data access
│   │   └── SubscriptionStatusesDALQueries.cs
│   ├── Subscriptions/                    # Subscription data access
│   │   ├── SubscriptionsDALCommands.cs
│   │   └── SubscriptionDALQueries.cs
│   ├── Trainer Assignments/              # Trainer assignment data access
│   │   ├── TrainerAssignmentsDALCommands.cs
│   │   └── TrainerAssignmentsDALQueries.cs
│   ├── Trainers/                         # Trainer data access
│   │   ├── TrainerDALCommands.cs
│   │   └── TrainersDALQueries.cs
│   └── Users/                            # User data access
│       ├── UsersDALCommands.cs
│       └── UsersDALQueries.cs
│
├── TitanGym_Presentation/                # Presentation Layer (WinForms)
│   ├── Core/                             # Core utilities
│   │   ├── Globals/                      # Global variables
│   │   │   └── Global.cs
│   │   ├── Helpers/                      # Helper classes
│   │   │   └── HelpersPL.cs
│   │   ├── Startup/                      # Application entry point
│   │   │   └── Program.cs
│   │   ├── Utility/                      # Utility functions
│   │   │   └── Utility.cs
│   │   └── Validation/                   # Validation logic
│   │       └── Validation.cs
│   ├── Modules/                          # Feature modules
│   │   ├── Dashboard/                    # Dashboard forms and controls
│   │   │   ├── Forms/
│   │   │   │   ├── UCDashboard.cs
│   │   │   │   └── UCDashboard.Designer.cs
│   │   ├── Login/                        # Login form
│   │   │   ├── Forms/
│   │   │   │   ├── UCLoginTitanGym.cs
│   │   │   │   └── UCLoginTitanGym.Designer.cs
│   │   ├── Main PL TitanGym/             # Main form and navigation
│   │   │   ├── MainPlTitanGymStartProgram.cs
│   │   │   ├── MainPlTitanGymStartProgram.Designer.cs
│   │   │   ├── UCScreenAccessDenied.cs
│   │   │   └── UCScreenAccessDenied.Designer.cs
│   │   ├── Members/                      # Member management
│   │   │   ├── Controls/
│   │   │   │   ├── ctrlShowInformationMember.cs
│   │   │   │   ├── ctrlShowInformationMember.Designer.cs
│   │   │   │   ├── ctrlShowInformationMemberWithFilter.cs
│   │   │   │   └── ctrlShowInformationMemberWithFilter.Designer.cs
│   │   │   └── Forms/
│   │   │       ├── UCAddEditInformationMember.cs
│   │   │       ├── UCAddEditInformationMember.Designer.cs
│   │   │       ├── UCMemberList.cs
│   │   │       ├── UCMemberList.Designer.cs
│   │   │       ├── UCShowInformationMember.cs
│   │   │       └── UCShowInformationMember.Designer.cs
│   │   ├── Payments/                     # Payment management
│   │   │   ├── Controls/
│   │   │   │   ├── ctrlShowInformationPayment.cs
│   │   │   │   └── ctrlShowInformationPayment.Designer.cs
│   │   │   └── Forms/
│   │   │       ├── UCAddEditPayments.cs
│   │   │       ├── UCAddEditPayments.Designer.cs
│   │   │       ├── UCPaymentsList.cs
│   │   │       ├── UCPaymentsList.Designer.cs
│   │   │       ├── UCShowInformationPayment.cs
│   │   │       └── UCShowInformationPayment.Designer.cs
│   │   ├── People/                       # Person management
│   │   │   ├── Controls/
│   │   │   │   ├── ctrlShowInformationPerson.cs
│   │   │   │   ├── ctrlShowInformationPerson.Designer.cs
│   │   │   │   ├── ctrlShowInformationPersonByFilter.cs
│   │   │   │   └── ctrlShowInformationPersonByFilter.Designer.cs
│   │   │   └── Forms/
│   │   │       ├── UCAddEditPerson.cs
│   │   │       ├── UCAddEditPerson.Designer.cs
│   │   │       ├── UCPeopleList.cs
│   │   │       ├── UCPeopleList.Designer.cs
│   │   │       ├── UCShowInformationPerson.cs
│   │   │       └── UCShowInformationPerson.Designer.cs
│   │   ├── Plans/                        # Membership plan management
│   │   │   ├── Controls/
│   │   │   │   ├── ctrlShowInformationMembershipPlan.cs
│   │   │   │   └── ctrlShowInformationMembershipPlan.Designer.cs
│   │   │   └── Forms/
│   │   │       ├── UCAddEditMembershipPlans.cs
│   │   │       ├── UCAddEditMembershipPlans.Designer.cs
│   │   │       ├── UCMembershipPlansList.cs
│   │   │       ├── UCMembershipPlansList.Designer.cs
│   │   │       ├── UCShowInformationMembershipPlan.cs
│   │   │       └── UCShowInformationMembershipPlan.Designer.cs
│   │   ├── Subscriptions/                # Subscription management
│   │   │   ├── Controls/
│   │   │   │   ├── ctrlShowInformationSubscription.cs
│   │   │   │   ├── ctrlShowInformationSubscription.Designer.cs
│   │   │   │   ├── ctrlShowInformationSubscriptionByFilter.cs
│   │   │   │   └── ctrlShowInformationSubscriptionByFilter.Designer.cs
│   │   │   └── Forms/
│   │   │       ├── UCAddEditSubscription.cs
│   │   │       ├── UCAddEditSubscription.Designer.cs
│   │   │       ├── UCShowInformationSubscription.cs
│   │   │       ├── UCShowInformationSubscription.Designer.cs
│   │   │       ├── UCSubscriptionsList.cs
│   │   │       └── UCSubscriptionsList.Designer.cs
│   │   ├── Trainer Assignments/          # Trainer assignment management
│   │   │   └── Forms/
│   │   │       ├── UCAddEditAssigementMember.cs
│   │   │       ├── UCAddEditAssigementMember.Designer.cs
│   │   │       ├── UCAssigementEditMemberTrainer.cs
│   │   │       ├── UCAssigementEditMemberTrainer.Designer.cs
│   │   │       ├── UCTrainerAssignmentsList.cs
│   │   │       └── UCTrainerAssignmentsList.Designer.cs
│   │   ├── Trainers/                     # Trainer management
│   │   │   ├── Controls/
│   │   │   │   ├── ctrlShowInformationTrainer.cs
│   │   │   │   └── ctrlShowInformationTrainer.Designer.cs
│   │   │   └── Forms/
│   │   │       ├── UCAddEditTrainer.cs
│   │   │       ├── UCAddEditTrainer.Designer.cs
│   │   │       ├── UCShowInformationTrainer.cs
│   │   │       ├── UCShowInformationTrainer.Designer.cs
│   │   │       ├── UCTrainersList.cs
│   │   │       └── UCTrainersList.Designer.cs
│   │   └── Users/                        # User management
│   │       ├── Controls/
│   │       │   ├── ctrlShowInformationUser.cs
│   │       │   └── ctrlShowInformationUser.Designer.cs
│   │       └── Forms/
│   │           ├── UCAddEditUser.cs
│   │           ├── UCAddEditUser.Designer.cs
│   │           ├── UCShowInformationUser.cs
│   │           ├── UCShowInformationUser.Designer.cs
│   │           ├── UCUsersList.cs
│   │           └── UCUsersList.Designer.cs
│   ├── Navigation/                       # Navigation helper
│   │   └── AppNavigator.cs
│   └── Properties/                       # Project resources
│       ├── Resources.resx
│       └── Settings.settings
│
├── Database/                             # Database scripts (NOT included in repo)
│   ├── Schema.sql                        # Table creation scripts
│   ├── Procedures.sql                    # Stored procedures and views
│   └── SeedData.sql                      # Initial data
│
├── TitanGym.sln                          # Visual Studio solution file
├── README.md                             # This file
└── LICENSE                               # MIT License

```
---

## 📂 Key File Descriptions

The project is structured into logical components, separating data access, business rules, utilities, and presentation logic:

| File Name | Layer / Type | Core Responsibilities & Description |
| :--- | :--- | :--- |
| **HelperDAL.cs** | Data Access | Manages database connections, executes parameterized queries, and provides data reading extensions. |
| **Utility.cs** | Utilities | Handles image saving/deleting, file operations, and "Remember Me" functionality. |
| **AppNavigator.cs** | Presentation | Manages the navigation stack using `Stack<UserControl>` to handle user control transitions seamlessly. |
| **Program.cs** | Application Core | The application entry point featuring the `STAThread` attribute and main form instantiation. |
| **Global.cs** | Utilities | Stores global variables (e.g., currently logged-in user information). |
| **HelpersPL.cs** | Presentation | Presentation layer helpers, such as extracting values from DataGridViews. |
| **Validation.cs** | Utilities | Provides utilities for email validation and general form input validation. |

---

## 🚀 How to Use

1. **System Initialization:** Launch the application from Visual Studio. The secure login screen will initialize.
2. **Administrator Access:** Authenticate using the default master credentials:
   * **Username:** `admin`
   * **Password:** `admin123`
3. **Registering a New Member:** 
   * Navigate to the `Members Management` tab.
   * Click `Add New Member`.
   * Fill out the core `Person` details (Name, Phone, Address).
   * Save to automatically generate a unique `MemberID`.
4. **Processing a Subscription:** 
   * Open the `Subscriptions` module.
   * Select the newly created member from the DataGrid.
   * Assign a membership plan (e.g., 3-Months Pro).
   * Process the transaction in the `Payments` window to activate the account.
5. **Trainer Linking:** Navigate to `Trainer Assignments` to pair the active member with a certified coach based on availability.

---


## 💡 Important Notes & Best Practices

* **Connection String Security:** The connection string is strictly referenced from `App.config` via `ConfigurationManager`. Never hardcode SQL credentials directly into the `DAL` classes.
* **Guna UI Initialization:** If form designer errors occur upon initial load, perform a full solution rebuild (`Ctrl + Shift + B`) to force Visual Studio to properly load the Guna framework DLLs.
* **Data Integrity:** The database utilizes foreign keys extensively. Ensure `People` records are created before linking them to `Members` or `Trainers` to avoid SQL constraint exceptions.

---

