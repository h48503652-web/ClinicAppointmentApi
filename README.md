# Clinic Appointment API

מערכת ניהול תורים במרפאה

### תיאור הפרויקט
מערכת לניהול תורים במרפאה. מאפשרת ניהול מטופלים, רופאים והזמנת תורים – מתאים כ-Back Office פשוט.

### ישויות
- Patient – מטופל  
- Doctor – רופא  
- Appointment – תור  

### Patients
| פעולה                  | Method | Route                        |
|-------------------------|--------|------------------------------|
| רשימת מטופלים          | GET    | /api/patients                |
| מטופל בודד             | GET    | /api/patients/{id}           |
| הוספת מטופל            | POST   | /api/patients                |
| עדכון מטופל            | PUT    | /api/patients/{id}           |
| מחיקה רכה              | PUT    | /api/patients/{id}/status    |

### Doctors
| פעולה                  | Method | Route                       |
|-------------------------|--------|-----------------------------|
| רשימת רופאים           | GET    | /api/doctors                |
| רופא בודד              | GET    | /api/doctors/{id}           |
| הוספת רופא             | POST   | /api/doctors                |
| עדכון רופא             | PUT    | /api/doctors/{id}           |
| מחיקה רכה              | PUT    | /api/doctors/{id}/status    |

### Appointments
| פעולה                  | Method | Route                             |
|--------|--------|-----------------------------------|
| רשימת תורים            | GET    | /api/appointments                 |
| תור בודד               | GET    | /api/appointments/{id}            |
| הוספת תור              | POST   | /api/appointments                 |
| עדכון תור              | PUT    | /api/appointments/{id}            |
| מחיקת תור              | DELETE | /api/appointments/{id}            |
| ביטול תור (פעולה נוספת)| PUT   | /api/appointments/{id}/cancel     |
