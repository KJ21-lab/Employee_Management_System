import { useState, useCallback, type ChangeEvent } from 'react';
import { Box, Card, Stack, CardContent, Typography, TextField, Alert, Snackbar, type SnackbarCloseReason } from '@mui/material';
import CustomButton from '../ReusableComponents/CustomButton';
import { useLoginMutation } from './LoginRoutes';
import { type LoginRequest } from './LoginModels';
import './Login.scss'
import { useNavigate } from 'react-router-dom';
const LoginPage = () => {

   const [login] = useLoginMutation();
   const navigate = useNavigate();
   const [barState, setBarState] = useState({ open: false, message: "", severity: "success" as "success" | "error" })
   const [LoginData, setLoginRequestData] = useState<LoginRequest>(() => {
      return {
         username: "",
         password: "",
      }
   });

   const handleCloseToast = (
      event?: React.SyntheticEvent | Event,
      reason?: SnackbarCloseReason
   ) => {
      if (reason === 'clickaway')
         return;

      setBarState((prev) => ({ ...prev, open: false }));
   };

   const handleLoginDataChange = useCallback((field: keyof LoginRequest, e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
      setLoginRequestData((prevData) => {
         return {
            ...prevData,
            [field]: e.target.value,
         };
      });
   }, []);

   const handleLogin = useCallback(async () => {
      try {
         const loginResult = await login({
            username: LoginData?.username || '',
            password: LoginData?.password || '',
         }).unwrap();

         setBarState({ open: true, message: "Login successful", severity: "success" });
         localStorage.setItem('token', loginResult.token);
         setTimeout(() => {
            navigate('/home');
         }, 500)

      } catch (error) {
         console.error("Failed to request login:", error);
         setBarState({ open: true, message: "Login request failed", severity: "error" });
      }
   }, [LoginData, login, navigate])

   return (
      <Box className='box-container'>

         <Card
            elevation={10}
            sx={{
               backgroundColor: 'white',
               borderRadius: '20px',
               width: '40%',
               height: '60%'
            }}>
            <CardContent>
               <Stack direction='column' spacing={5} alignItems='center'>
                  <Typography variant='h4' align='center' sx={{ fontWeight: '700', fontSize: '2rem' }}>
                     Login
                  </Typography>

                  <TextField
                     variant='standard'
                     type='text'
                     label="Username"
                     placeholder='Enter Username'
                     onChange={(e) => handleLoginDataChange('username', e)}
                     sx={{ width: '80%' }}>
                  </TextField>

                  <TextField
                     variant='standard'
                     label="Password"
                     type='password'
                     placeholder='Enter password'
                     onChange={(e) => handleLoginDataChange('password', e)}
                     sx={{ width: '80%' }}>
                  </TextField>

                  <CustomButton
                     variant='contained'
                     onClick={handleLogin}
                     sx={{ width: '40%', height: '50%' }}>
                     Login
                  </CustomButton>
               </Stack>
            </CardContent>
         </Card>
         <Snackbar
            open={barState.open}
            autoHideDuration={6000}
            onClose={handleCloseToast}
            sx={{ width: '20%' }}>

            <Alert
               severity={barState.severity}
               variant="filled"
               sx={{ width: '100%' }}>
               {barState.message}
            </Alert>

         </Snackbar>
      </Box>
   )
}

export default LoginPage;