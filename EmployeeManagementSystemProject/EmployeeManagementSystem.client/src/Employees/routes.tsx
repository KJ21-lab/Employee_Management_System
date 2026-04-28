import { createApi } from '@reduxjs/toolkit/query/react';
import type { Employee } from './types'; // Imports the TypeScript Habit interface from the types.ts file.
import { baseQueryWithReauth } from '../Authenitication/LoginRoutes'

// Define a service using a base URL and expected endpoints
export const employeeApi = createApi({
   reducerPath: 'employeeApi',
   baseQuery: baseQueryWithReauth,

   tagTypes: ['Employees'],
   endpoints: (build) => ({
      getEmployees: build.query<Employee[], void>({
         query: () => `Employee/GetEmployees`,
         providesTags: ['Employees'],
      }),
   }),
})

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints
export const { useGetEmployeesQuery } = employeeApi