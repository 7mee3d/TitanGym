
-- =====================================================
				-- GYM Management System 
-- =====================================================

-- Create The DB = GYM Management System =


IF DB_ID('GYM_ManagementSystem') IS NULL 
BEGIN 

		CREATE DATABASE GYM_ManagementSystem
END 

GO 

USE GYM_ManagementSystem

GO 
-- Lookup

CREATE TABLE dbo.MembershipStatuses (
    MembershipStatusID INT PRIMARY KEY IDENTITY(1,1),
    NameMembershipStatus NVARCHAR(300) NOT NULL
);

CREATE TABLE dbo.AvailabilityStatuses (
    AvailabilityStatusID INT PRIMARY KEY IDENTITY(1,1),
    NameAvailabilityStatus NVARCHAR(300) NOT NULL
);

CREATE TABLE dbo.SubscriptionStatuses (
    SubscriptionStatusID INT PRIMARY KEY IDENTITY(1,1),
    NameSubscriptionStatus VARCHAR(300) NOT NULL
);

CREATE TABLE dbo.AttendanceStatuses (
    AttendanceStatusID INT PRIMARY KEY IDENTITY(1,1),
    NameAttendanceStatus NVARCHAR(300) NOT NULL
);

CREATE TABLE dbo.PaymentMethods (
    PaymentMethodID INT PRIMARY KEY IDENTITY(1,1),
    NamePaymentMethod NVARCHAR(300) NOT NULL
);

CREATE TABLE dbo.PaymentStatuses (
    PaymentStatusID INT PRIMARY KEY IDENTITY(1,1),
    NamePaymentStatus NVARCHAR(300) NOT NULL
);

CREATE TABLE dbo.Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(300) NOT NULL,
    RoleStatus BIT NOT NULL DEFAULT 1,
    PermissionsRole TINYINT NOT NULL DEFAULT 0
);

CREATE TABLE dbo.AccountStatuses (
    AccountStatusID INT PRIMARY KEY IDENTITY(1,1),
    AccountStatusName NVARCHAR(300) NOT NULL
);

CREATE TABLE dbo.EmploymentStatuses (
    EmploymentStatusID INT PRIMARY KEY IDENTITY(1,1),
    NameEmploymentStatus NVARCHAR(300) NOT NULL
);

CREATE TABLE dbo.Specializations (
    SpecializationID INT PRIMARY KEY IDENTITY(1,1),
    SpecializationName NVARCHAR(300) NOT NULL
);

GO




CREATE TABLE dbo.People (

    PersonID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(25) NOT NULL,
    SecondName NVARCHAR(25) NULL,
    ThirdName NVARCHAR(25) NULL,
    LastName NVARCHAR(25) NOT NULL,
    Gender CHAR(1) NULL,
    PhoneNumber VARCHAR(15) NULL,
    EmailAddress NVARCHAR(350) NULL,
    ResidentialAddress NVARCHAR(MAX) NULL,
    DateOfBirth DATETIME2 NULL

);

CREATE TABLE dbo.Memberships (

    MembershipID INT PRIMARY KEY IDENTITY(1,1),
    MembershipName NVARCHAR(300) NOT NULL,
    Duration TINYINT NOT NULL,
    MonthlyPrice DECIMAL(10,2) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    AvailabilityStatusID INT NOT NULL,

    CONSTRAINT FK_Memberships_AvailabilityStatuses 
        FOREIGN KEY (AvailabilityStatusID) REFERENCES dbo.AvailabilityStatuses(AvailabilityStatusID)

);

CREATE TABLE dbo.Members (

    MemberID INT PRIMARY KEY IDENTITY(1,1),
    EmergencyContactPhoneNumber VARCHAR(15) NULL,
    EmergencyContactName NVARCHAR(350) NULL,
    RegistrationDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    MembershipStatusID INT NOT NULL,
    PersonID INT NOT NULL,

    CONSTRAINT FK_Members_MembershipStatuses 
        FOREIGN KEY (MembershipStatusID) REFERENCES dbo.MembershipStatuses(MembershipStatusID),
    CONSTRAINT FK_Members_People 
        FOREIGN KEY (PersonID) REFERENCES dbo.People(PersonID)

);

CREATE TABLE dbo.Users (

    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(300) NOT NULL UNIQUE,
    Password CHAR(200) NOT NULL,
    CreationDateUser DATETIME2 NOT NULL DEFAULT GETDATE(),
    AccountStatusID INT NOT NULL,
    PersonID INT NOT NULL,
    RoleID INT NOT NULL,

    CONSTRAINT FK_Users_AccountStatuses 
        FOREIGN KEY (AccountStatusID) REFERENCES dbo.AccountStatuses(AccountStatusID),
    CONSTRAINT FK_Users_People 
        FOREIGN KEY (PersonID) REFERENCES dbo.People(PersonID),
    CONSTRAINT FK_Users_Roles 
        FOREIGN KEY (RoleID) REFERENCES dbo.Roles(RoleID)

);

CREATE TABLE dbo.Trainers (

    TrainerID INT PRIMARY KEY IDENTITY(1,1),
    HireDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    Salary DECIMAL(10,2) NULL,
    SpecializationID INT NULL,
    EmploymentStatusID INT NOT NULL,
    PersonID INT NOT NULL,
    CONSTRAINT FK_Trainers_Specializations 
        FOREIGN KEY (SpecializationID) REFERENCES dbo.Specializations(SpecializationID),
    CONSTRAINT FK_Trainers_EmploymentStatuses 
        FOREIGN KEY (EmploymentStatusID) REFERENCES dbo.EmploymentStatuses(EmploymentStatusID),
    CONSTRAINT FK_Trainers_People 
        FOREIGN KEY (PersonID) REFERENCES dbo.People(PersonID)

);

CREATE TABLE dbo.Subscriptions (

    SubscriptionID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATETIME2 NOT NULL,
    EndDate DATETIME2 NOT NULL,
    SubscriptionFees DECIMAL(10,2) NOT NULL,
    SubscriptionStatusID INT NOT NULL,
    MemberID INT NOT NULL,
    MembershipID INT NOT NULL,

    CONSTRAINT FK_Subscriptions_SubscriptionStatuses 
        FOREIGN KEY (SubscriptionStatusID) REFERENCES dbo.SubscriptionStatuses(SubscriptionStatusID),
    CONSTRAINT FK_Subscriptions_Members 
        FOREIGN KEY (MemberID) REFERENCES dbo.Members(MemberID),
    CONSTRAINT FK_Subscriptions_Memberships 
        FOREIGN KEY (MembershipID) REFERENCES dbo.Memberships(MembershipID)

);

CREATE TABLE dbo.Attendances (

    AttendanceID INT PRIMARY KEY IDENTITY(1,1),
    CheckInDate DATETIME2 NOT NULL,
    CheckInTime TIME(2) NOT NULL,
    CheckOutTime TIME(2) NULL,
    AttendanceStatusID INT NOT NULL,
    MemberID INT NOT NULL,

    CONSTRAINT FK_Attendances_AttendanceStatuses 
        FOREIGN KEY (AttendanceStatusID) REFERENCES dbo.AttendanceStatuses(AttendanceStatusID),
    CONSTRAINT FK_Attendances_Members 
        FOREIGN KEY (MemberID) REFERENCES dbo.Members(MemberID)

);

CREATE TABLE dbo.Payments (

    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    Amount DECIMAL(10,2) NOT NULL,
    PaymentDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    Note NVARCHAR(MAX) NULL,
    PaymentMethodID INT NOT NULL,
    PaymentStatusID INT NOT NULL,
    SubscriptionID INT NOT NULL,

    CONSTRAINT FK_Payments_PaymentMethods 
        FOREIGN KEY (PaymentMethodID) REFERENCES dbo.PaymentMethods(PaymentMethodID),
    CONSTRAINT FK_Payments_PaymentStatuses 
        FOREIGN KEY (PaymentStatusID) REFERENCES dbo.PaymentStatuses(PaymentStatusID),
    CONSTRAINT FK_Payments_Subscriptions 
        FOREIGN KEY (SubscriptionID) REFERENCES dbo.Subscriptions(SubscriptionID)

);

CREATE TABLE dbo.TrainerAssignments (

    TrainerAssignmentID INT PRIMARY KEY IDENTITY(1,1),
    AssignmentDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    Note NVARCHAR(MAX) NULL,
    TrainerID INT NOT NULL,
    MemberID INT NOT NULL,

    CONSTRAINT FK_TrainerAssignments_Trainers 
        FOREIGN KEY (TrainerID) REFERENCES dbo.Trainers(TrainerID),
    CONSTRAINT FK_TrainerAssignments_Members 
        FOREIGN KEY (MemberID) REFERENCES dbo.Members(MemberID)

);

