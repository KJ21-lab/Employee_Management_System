import { useState, useCallback, type ChangeEvent} from 'react';
import { Box, Card, Stack, CardContent, Typography, TextField, Alert, Snackbar } from '@mui/material';
import CustomButton from '../ReusableComponents';
import { useLoginMutation } from './LoginRoutes';
import { type LoginRequest } from './LoginModels';
import './Login.scss'
const LoginPage = () => {

   const [login] = useLoginMutation();
   const [LoginData, setLoginRequestData] = useState<LoginRequest>(() => {
      return {
         username: "",
         password: "",
      }
   });

   const handleLoginDataChange = useCallback((field: keyof LoginRequest, e: ChangeEvent<HTMLInputElement|HTMLTextAreaElement>) => {
      setLoginRequestData((prevData) => {
         return {
            ...prevData,
            [field]: e.target.value,
         };
      });
   }, []);

   const handleLogin = useCallback(async () => {
      try {
         await login({
            username: LoginData?.username || '',
            password: LoginData?.password || '',
         }).unwrap();
         <Snackbar open={true} autoHideDuration={6000}>
            <Alert
               severity="success"
               variant="filled"
               sx={{ width: '100%' }}>
               Login Requested!
            </Alert>
         </Snackbar>
      } catch (error) {
         console.error("Failed to request login:", error);
         <Snackbar open={true} autoHideDuration={6000}>
            <Alert
               severity="error"
               variant="filled"
               sx={{ width: '100%' }}>
               Failed to request login.
            </Alert>
         </Snackbar>
      }
   }, [LoginData, login])

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
      </Box>
   )
}

export default LoginPage;