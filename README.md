# 🚌 Bus Reservation Management System

A desktop-based **Bus Reservation Management System** developed as an academic group project using **C# Windows Forms, .NET Framework, MySQL, and Visual Studio**.

The system provides separate modules for **Passengers and Administrators**, supporting bus search, seat reservation, payment management, reservation tracking, user management, and reporting.

---

## ✨ Features

### 👤 Passenger Module

* User Registration and Login
* Search buses by route
* View bus and travel details
* Dynamic seat selection
* Seat reservation
* Payment management
* Booking confirmation
* View reservation history
* View recent payments
* Manage passenger profile

### 🔐 Administrator Module

* Admin Dashboard
* Manage buses
* Manage reservations
* Manage users
* Manage payments
* Process refunds
* Generate reports
* Manage reservation status
* Manage seat availability

---

## 🛠️ Technologies Used

| Technology               | Purpose                 |
| ------------------------ | ----------------------- |
| **C#**                   | Application development |
| **Windows Forms**        | Desktop user interface  |
| **.NET Framework 4.7.2** | Application framework   |
| **MySQL**                | Database management     |
| **Visual Studio**        | Development environment |
| **iTextSharp**           | PDF report generation   |

---

## 🗄️ Database

The system uses **MySQL** as the backend database.

### Main Database Tables

* `users` – Stores passenger and administrator information
* `buses` – Stores bus, route, and travel information
* `reservations` – Stores reservation and booking details
* `seat_availability` – Manages seat availability
* `payments` – Stores payment and refund information

---

## 🖥️ System Workflow

### Passenger Side

`Login / Register → Search Bus → Select Seats → Payment → Booking Confirmation → Reservations`

### Administrator Side

`Admin Dashboard → Manage Buses → Manage Reservations → Manage Users → Manage Payments → Reports`

---

## 📸 Screenshots

Screenshots demonstrating the main features and user interfaces of the system will be added here.

### Passenger Interface

* Login & Registration
* Passenger Dashboard
* Bus Search
* Seat Selection
* Payment
* Booking Confirmation
* Reservation History
* Passenger Profile

### Administrator Interface

* Admin Dashboard
* Bus Management
* Reservation Management
* User Management
* Payment Management
* Reports

---

## 🚀 How to Run

### Prerequisites

Make sure the following are installed:

* **Visual Studio**
* **.NET Framework 4.7.2**
* **MySQL Server**
* **MySQL Workbench** or another MySQL database management tool

### Setup

1. Clone or download this repository.
2. Open the `.sln` solution file in **Visual Studio**.
3. Create the required MySQL database.
4. Import the provided `.sql` database script.
5. Update the database connection string according to your local MySQL configuration.
6. Build the solution in Visual Studio.
7. Run the application.

> **Note:** Database credentials and connection settings may need to be updated according to your local environment.

---

## 📚 Project Information

This project was developed as an **academic group project** to demonstrate practical knowledge of:

* Desktop application development
* Object-oriented programming
* Database management
* CRUD operations
* User interface design
* Reservation and payment management
* Software development and testing

---

## 👥 Project Team

This system was developed collaboratively as a **group academic project** by undergraduate students of the **University of Ruhuna, Sri Lanka**.

### My Contribution

**SADUNI RAMESHIKA**
ICT Undergraduate
University of Ruhuna, Sri Lanka

Contributed to the development of the **C# Windows Forms application, MySQL database designing and integration, user interface development, reservation and system workflow, and system testing**.

---

## 📌 Project Status

**Completed Academic Project**

The core passenger and administrator functionalities have been implemented as part of the academic project.

---

⭐ If you find this project useful, feel free to explore the repository.
