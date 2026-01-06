import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import type { LoginRequest } from './LoginModels';

export const loginApi = createApi({
   reducerPath: 'loginApi',
   baseQuery: fetchBaseQuery({ baseUrl: '/api/' }),

   tagTypes: ['Login'],
   endpoints: (build) => ({
      Login: build.mutation<void, LoginRequest>({
         query: (credentials) =>  ({
            url: 'login',
            method: 'POST',
            body: credentials,
         })
      }),
   }),
})

export const { useLoginMutation } = loginApi