import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
//import EmployeeIndex from './EmployeeIndex.tsx'
import { Provider } from 'react-redux';
import { store } from './store.ts';
import { RouterProvider } from 'react-router-dom';
import { router } from './Router.tsx';
import { createTheme, CssBaseline, ThemeProvider } from '@mui/material';

const theme = createTheme({
   typography: {
      fontFamily: [
         'Roboto',
      ].join(','),
   },
});

createRoot(document.getElementById('root')!).render(
   <StrictMode>
      <ThemeProvider theme={theme}>
         <CssBaseline />
         <Provider store={store}>
            {/*<EmployeeIndex />*/}
            <RouterProvider router={router} />
         </Provider>
      </ThemeProvider>
   </StrictMode>,
)