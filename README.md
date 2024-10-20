# ClinicSystem

**ClinicSystem** is a console-based management system for a Doctor's clinic, aiding in appointments, scheduling, and follow-ups. It uses a class-based architecture to mirror real-world clinic operations.

### Key Features
- **Appointment Management**: Handle customer appointments.
- **Doctor Scheduling**: Manage the doctor's schedule.
- **Assistant Panel**: Interface for managing customer interactions.
- **Doctor Panel**: Interface for viewing and managing appointments.

### Class Structure
The project follows object-oriented principles with key classes:
- **Account.cs**: Generic account functionalities.
- **Appointment.cs**: Manages appointments.
- **Assistant.cs**: Interacts with the appointment system.
- **Customer.cs**: Customer details and interactions.
- **Doctor.cs**: Doctor's schedule and appointments.
- **DB.cs**: Simulates a database.
- **Program.cs**: Entry point.
- **AssistantMenu.cs**: Assistant's console interface.
- **DoctorMenu.cs**: Doctor’s console interface.
- **ClinicSystem.cs**: Central controller.

### Console Controller Methods
Controller methods for console interaction include:
- Customer Appointment Booking
- Assistant Approval of Appointments
- Doctor Schedule Management
- Customer Follow-ups

### Class Diagram
The class diagram shows:
- **Doctor** with multiple **Appointments** and interactions with **Assistant**.
- **Assistant** managing **Customers** and **Appointments**.
- **ClinicSystem** coordinating information flow.

### Future Extensions
Potential extensions include:
- GUI integration.
- Database connectivity.
- Additional roles like nurses.

### Installation
1. Clone the repository:
    ```
    git clone https://github.com/mahmoud-40/ClinicSystem.git
    ```
2. Open in your preferred C# IDE.
3. Run **Program.cs** to start the application.
