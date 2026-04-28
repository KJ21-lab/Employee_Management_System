import { createApi, fetchBaseQuery, type BaseQueryFn, type FetchArgs, type FetchBaseQueryError } from '@reduxjs/toolkit/query/react';
import type { LoginRequest, LoginResponse } from './LoginModels';

// Authentication/baseQuery.ts

const rawBaseQuery = fetchBaseQuery({
   baseUrl: '/api/',
   prepareHeaders: (headers) => {
      const token = localStorage.getItem('token');
      if (token) headers.set('authorization', `Bearer ${token}`);
      return headers;
   },
});

export const baseQueryWithReauth: BaseQueryFn<string | FetchArgs, unknown, FetchBaseQueryError> = async (args, api, extraOptions) => {
   let result = await rawBaseQuery(args, api, extraOptions);

   if (result.error?.status === 401) {
      localStorage.removeItem('token');
      window.location.href = '/';
   }
   return result;
};

export const loginApi = createApi({
   reducerPath: 'loginApi',
   baseQuery: baseQueryWithReauth,
   tagTypes: ['Login'],
   endpoints: (build) => ({
      Login: build.mutation<LoginResponse, LoginRequest>({
         query: (credentials) => ({
            url: 'login',
            method: 'POST',
            body: credentials,
         })
      }),
   }),
})

export const { useLoginMutation } = loginApi;