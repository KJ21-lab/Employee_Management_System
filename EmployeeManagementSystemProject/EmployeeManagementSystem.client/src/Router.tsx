import {
  BrowserRouter,
  Routes,
  Route,
  Navigate,
  useLocation,
  createBrowserRouter,
} from "react-router-dom";
import { LoginPage } from './Authenitication/Login';
import { Layout } from './InitialLayout';

const Loading: React.FC = () => <div>Loading...</div>;

export const router = createBrowserRouter([
   {
      path: "/",
      element: <Layout/>,
     /* errorElement: ,*/
      //children: [
      //   // --- PUBLIC ROUTES ---
      //   {
      //      path: "/login",
      //      element: <LoginPage />,
      //   },

      //]
   }
]);