import { createApi } from '@reduxjs/toolkit/query/react';
import type { Employee } from './types';
import { baseQueryWithReauth } from '../Authenitication/LoginRoutes'

// Define a service using a base URL and expected endpoints
export const employeeApi = createApi({
   reducerPath: 'employeeApi',
   baseQuery: baseQueryWithReauth,

   tagTypes: ['Employees'],
   endpoints: (build) => ({
      getEmployees: build.query<Employee[], void>({
         query: () => `Employee/GetEmployees`,
         providesTags: ['Employees']
      }),
      createEmployee: build.mutation<void, Employee>({
         query: (newEmployee) => ({
            url: 'Employee/CreateEmployee',
            method: 'POST',
            body: {
               employee_name: newEmployee.name,
               employee_job_title: newEmployee.jobTitle,
               employee_hire_date: newEmployee.hireDate,
               employee_id: String(newEmployee.employeeID),
            },
         }),
         invalidatesTags: ['Employees']
      }),
      updateEmployee: build.mutation<void, Employee>({
         query: (updatedEmployee) => ({
            url: 'Employee/UpdateEmployee',
            method: 'PUT',
            body: {
               employee_name: updatedEmployee.name,
               employee_job_title: updatedEmployee.jobTitle,
               employee_hire_date: updatedEmployee.hireDate,
               employee_id: String(updatedEmployee.employeeID),
            },
         }),
         invalidatesTags: ['Employees']
      })
   }),
})

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints
export const {
   useGetEmployeesQuery,
   useCreateEmployeeMutation,
   useUpdateEmployeeMutation} = employeeApi