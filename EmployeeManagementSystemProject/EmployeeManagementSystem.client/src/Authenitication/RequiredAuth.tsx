import { useLocation, Navigate, Outlet } from "react-router-dom";

const RequiredAuth = () => {
   // 1. Get the current location (so we can send them back here after login)
   const location = useLocation();

   // 2. Check for the token (the "ID Card")
   // In a real app, you might check a Redux state here instead
   const token = localStorage.getItem('token');

   // 3. The Logic
   return (
      token
         ? <Outlet />  // <--- SUCCESS: Render the requested page (Dashboard, Home, etc.)
         : <Navigate to="/" state={{ from: location }} replace /> // <--- FAIL: Redirect to Login
   );
}

export default RequiredAuth;