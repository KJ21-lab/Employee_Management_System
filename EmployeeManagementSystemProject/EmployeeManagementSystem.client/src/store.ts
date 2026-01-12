import { configureStore } from '@reduxjs/toolkit';
import { employeeApi } from './Employees/routes';
import { loginApi } from './Authenitication/LoginRoutes';

export const store = configureStore({
   reducer: {
      [employeeApi.reducerPath]: employeeApi.reducer,
      [loginApi.reducerPath]: loginApi.reducer,
   },
   // Adding the api middleware enables caching, invalidation, polling,
   // and other useful features of RTK Query.
   middleware: (getDefaultMiddleware) =>
      getDefaultMiddleware().concat(employeeApi.middleware)
                            .concat(loginApi.middleware)
});

// Optional: Infer types for RootState and AppDispatch
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;