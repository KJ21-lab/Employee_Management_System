import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import type { Habit } from './types'; // Imports the TypeScript Habit interface from the types.ts file.

// Define a service using a base URL and expected endpoints
export const habitApi = createApi({
  reducerPath: 'habitApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'http://localhost:5188/api/' }),

   tagTypes: ['Habits'],
  endpoints: (build) => ({
    getHabits: build.query<Habit[], void>({
      query: () => `Habit/GetHabits`,
      providesTags: ['Habits'],
    }),
  }),
})

// Export hooks for usage in functional components, which are
// auto-generated based on the defined endpoints
export const { useGetHabitsQuery } = habitApi