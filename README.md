# iSchoolMobile-API

A comprehensive school management API for the iSchool Mobile application, providing backend services for students, faculty, administration, and other stakeholders in the educational ecosystem.

## Project Overview

iSchoolMobile-API is a RESTful API built with ASP.NET Core that manages all aspects of a higher education institution, including student records, course enrollment, faculty management, financial transactions, library resources, and research projects.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication
- AutoMapper

## Features

The API provides endpoints for the following functional areas:

### Authentication and User Management
- User registration and login 
- Role-based access control
- JWT token authentication

### Academic Management
- Course registration and management
- Department and faculty organization
- Student grade tracking
- Transcript generation and download

### Financial Management
- Student fee tracking
- Payment processing
- Financial record management

### Library Resources
- Book and resource management
- Resource borrowing and returns
- Digital resource access

### Research Projects
- Research project management
- Document uploads and sharing
- Contributor management

### Evaluation System
- Lecturer evaluations
- Course evaluations
- Evaluation response tracking

## Database Structure

The system maintains a comprehensive data model including:

- Students, faculty, and administration users
- Courses organized by departments within faculties
- Registration periods and course enrollments
- Financial records and payment tracking
- Library resources and borrowing records
- Research projects and documents
- Evaluations and responses

## TODOs

The following features are planned for future implementation:

### Course Management
- Implement course creation functionality
- Build course update endpoints
- Add course deletion capabilities with proper validations

### Evaluation System
- Complete evaluation report generation
- Implement notification system for evaluation periods
- Add visualization components for evaluation results

### Finance Module
- Implement payment gateway integration
- Add invoice generation
- Create financial reporting features

### Research
- Implement document upload and management
- Add collaboration features
- Create citation and publishing tools

### Library Module
- Build digital resource streaming capability
- Add reservation system for high-demand resources
- Implement fine calculation and payment for late returns

## Getting Started

### Prerequisites
- .NET SDK (7.0+)
- SQL Server
- Visual Studio or JetBrains Rider

### Installation
1. Clone the repository
2. Update connection string in `appsettings.json` to point to your SQL Server instance
3. Run migrations to create the database structure:
