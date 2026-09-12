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
      createEmployees: build.mutation<void, Employee>({
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
      })
   }),
})

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints
export const {
   useGetEmployeesQuery,
   useCreateEmployeesMutation } = employeeApi