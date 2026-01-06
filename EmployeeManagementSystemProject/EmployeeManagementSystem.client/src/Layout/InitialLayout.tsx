import { AppBar, Box, Stack, Toolbar } from '@mui/material'
import PersonIcon from '@mui/icons-material/Person';
import './Layout.scss'
import { Outlet } from 'react-router-dom';


export const Layout = () => {

   return (
      <div style={{ display: 'flex', flexDirection: 'column', height: '100vh' }}>
         <Stack direction="row" spacing={0} sx={{ height: '100%' }}>

            <Box className='menu-bar-vertical' />

            <Box className='background-box' sx={{ display: 'flex', flexDirection: 'column' }}>

               <AppBar position='static' elevation={0}>
                  <Toolbar sx={{ backgroundColor: 'white', fontFamily: 'Roboto' }}>
                     <PersonIcon sx={{ mr: 2, backgroundColor: '#3F51B5' }} />
                  </Toolbar>
               </AppBar>
               <Outlet />
            </Box>
         </Stack>
      </div>

   )
}