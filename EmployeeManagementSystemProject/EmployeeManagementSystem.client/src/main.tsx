import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
//import './index.css'
//import EmployeeIndex from './EmployeeIndex.tsx'
import { Provider } from 'react-redux';
import { store } from './store.ts';
import { RouterProvider } from 'react-router-dom';
import { router } from './Router.tsx';

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <Provider store={store}>
         {/*<EmployeeIndex />*/}
         <RouterProvider router={router} />
        </Provider>
    </StrictMode>,
)