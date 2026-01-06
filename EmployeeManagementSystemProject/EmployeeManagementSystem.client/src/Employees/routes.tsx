import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import type { Employee } from './types'; // Imports the TypeScript Habit interface from the types.ts file.

// Define a service using a base URL and expected endpoints
export const employeeApi = createApi({
   reducerPath: 'employeeApi',
   baseQuery: fetchBaseQuery({ baseUrl: '/api/' }),

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