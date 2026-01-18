import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import type { Account } from './types'; // Imports the TypeScript Habit interface from the types.ts file.

// Define a service using a base URL and expected endpoints
export const accountsApi = createApi({
   reducerPath: 'accountsApi',
   baseQuery: fetchBaseQuery({ baseUrl: '/api/' }),

   tagTypes: ['Accounts'],
   endpoints: (build) => ({
      getAccounts: build.query<Account[], void>({
         query: () => `Accounts/GetAccounts`,
         providesTags: ['Accounts'],
      }),
   }),
})

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints
export const { useGetAccountsQuery } = accountsApi