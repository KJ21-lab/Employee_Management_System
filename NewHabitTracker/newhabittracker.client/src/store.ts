// src/store.ts (or src/app/store.ts)
import { configureStore } from '@reduxjs/toolkit';
import { employeeApi } from './routes'; // Import your API definition

export const store = configureStore({
  reducer: {
        [employeeApi.reducerPath]: employeeApi.reducer,
  },
  // Adding the api middleware enables caching, invalidation, polling,
  // and other useful features of RTK Query.
  middleware: (getDefaultMiddleware) =>
      getDefaultMiddleware().concat(employeeApi.middleware),
});

// Optional: Infer types for RootState and AppDispatch
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;