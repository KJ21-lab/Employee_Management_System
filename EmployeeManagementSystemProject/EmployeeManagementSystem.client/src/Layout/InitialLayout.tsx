import { AppBar, Box, Card, CardContent, List, ListItem, ListItemButton, ListItemIcon, ListItemText, Stack, Toolbar } from '@mui/material'
import PersonIcon from '@mui/icons-material/Person';
import HomeIcon from '@mui/icons-material/Home';
import './Layout.scss'
import { Link, Outlet } from 'react-router-dom';


export const Layout = () => {

   return (
      <Box style={{ display: 'flex', flexDirection: 'column', height: '100vh',  overflowY: 'auto' }}>
         <AppBar position='static' elevation={0}>
            <Toolbar sx={{ backgroundColor: 'white', fontFamily: 'Roboto' }}>
               <PersonIcon sx={{ mr: 2, backgroundColor: '#3F51B5' }} />
            </Toolbar>
         </AppBar>
         <Stack direction="row" spacing={0} sx={{ height: '100%' }}>
            <Card sx={{width: '13%', height: '100%'}}>
               <CardContent sx={{ height: '100%', width: '100%', backgroundColor: '#000033'} }>
               <List sx={{ mt: 2}}>

                  {/* Home */}
                  <ListItem
                     disablePadding
                     component={Link} to={'/home'}
                     sx={{
                        cursor: 'pointer',
                        '&:hover': {
                           backgroundColor: 'rgba(255, 255, 255, 0.2)',
                        }
                     }}>
                     <ListItemButton>
                        <ListItemIcon>
                           <HomeIcon sx={{ color: 'white' }} />
                        </ListItemIcon>
                        <ListItemText primary="Home" sx={{ color: 'white' }} />
                     </ListItemButton>
                  </ListItem>

                  {/* Employee List */}
                  <ListItem
                     disablePadding
                     component={Link} to={'/employees'}
                     sx={{
                        cursor: 'pointer',
                        '&:hover': {
                           backgroundColor: 'rgba(255, 255, 255, 0.2)',
                        }
                     }}>
                     <ListItemButton>
                        <ListItemIcon>
                           <PersonIcon sx={{ color: 'white' }} />
                        </ListItemIcon>
                        <ListItemText primary="Employees" sx={{ color: 'white' }} />
                     </ListItemButton>
                  </ListItem>

                  </List>
               </CardContent>
            </Card>

            <Box className='background-box' sx={{ display: 'flex', flexDirection: 'column' }}>

              
               <Outlet />

            </Box>
         </Stack>
      </Box>

   )
}