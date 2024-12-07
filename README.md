# School Management Web API 🚀  

## Overview  
The **School Management Web API** is a scalable and robust system designed to streamline the management of school operations, including teachers, students, and administrative tasks. Built with **Clean Architecture** and modern development patterns, this API is optimized for performance, maintainability, and security.  

---

## Features  
### User Management  
- Manage **Teachers**, **Students**, and **Admins**.  
- Track employment details for teachers, including **Salary** and **Contract Type**.  
- Apply **Soft Delete** functionality for Teachers, Students, and Sections.  

### Enrollment Management  
- Handle **Course Enrollments** with support for courses that have prerequisites.  
- Optimize schedules for sections with conflict-free assignments.  

### Section-Teacher Relationships  
- Manage associations between teachers and their assigned sections.  

---

## Technology Stack  
### Architecture and Patterns  
- **Clean Architecture**  
- **CQRS** (Command and Query Responsibility Segregation)  
- **Repository Pattern**  
- **Builder Pattern**  

### Backend Framework  
- **ASP.NET Core**  
- **Entity Framework Core** with **AutoMapper**  

### Authentication and Validation  
- **JWT Authentication**  
- **Custom IdentityUser** for tailored user management.  
- **Fluent Validation** for consistent request validation.  

### Database Optimization  
- **Stored Procedures** for encapsulating complex business logic.  
- **Table Variables**, **CTEs**, and **Temporary Tables** for efficient data handling.  



