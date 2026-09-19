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
         providesTags: (result) =>
            result
               ? [
                  ...result.map(({ employeeUID }) => ({ type: 'Employees' as const, employeeUID })),
               { type: 'Employees', id: 'LIST' },
                 ]
               : [{ type: 'Employees', id: 'LIST' }]
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
         invalidatesTags: [{ type: 'Employees', id: 'LIST' }]
      }),
      updateEmployee: build.mutation<void, Employee>({
         query: (updatedEmployee) => ({
            url: 'Employee/UpdateEmployee',
            method: 'PUT',
            body: {
               employee_uid: updatedEmployee.employeeUID,
               employee_name: updatedEmployee.name,
               employee_job_title: updatedEmployee.jobTitle,
               employee_hire_date: updatedEmployee.hireDate,
               employee_id: String(updatedEmployee.employeeID),
            },
         }),
         invalidatesTags: (result, error, updatedEmployee) => [
            { type: 'Employees', id: updatedEmployee.employeeUID },
            'Employees',
         ],
      }),
       deleteEmployee: build.mutation<void, string>({
          query: (employee_uid) => ({
             url: `Employee/DeleteEmployee/${employee_uid}`,
             method: 'DELETE',
          }),
          invalidatesTags: (result, error, employeeUid) => [
             { type: 'Employees', id: employeeUid },
             { type: 'Employees', id: 'LIST' }
          ],
       }),
   }),
})

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints
export const {
   useGetEmployeesQuery,
   useCreateEmployeeMutation,
   useUpdateEmployeeMutation,
   useDeleteEmployeeMutation } = employeeApi