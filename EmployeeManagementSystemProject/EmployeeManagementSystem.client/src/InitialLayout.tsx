import { AppBar, Box, Card, Stack, Toolbar, CardContent, Typography } from '@mui/material'
import PersonIcon from '@mui/icons-material/Person';
import './Layout.scss'

export const Layout = () => {
   return (
      <div style={{ display: 'flex', flexDirection: 'column', height: '100vh' }}>
         {/*<Box*/}
         {/*   sx={{*/}
         {/*      width: '100vw',*/}
         {/*      height: '100vh',*/}
         {/*      borderRadius: '5px 5px 5px 5px',*/}
         {/*      bgcolor: '#f0f0f0',*/}
         {/*      flexDirection: 'row'*/}
         {/*   }}>*/}
         {/*</Box>*/}
         {/*<Box*/}
         {/*   sx={{*/}
         {/*      width: '30vh',*/}
         {/*      height: '100%',*/}
         {/*      borderRadius: '5px 0 0 4px',*/}
         {/*      bgcolor: '#000033',*/}
         {/*      flexDirection: 'row'*/}
         {/*   }}>*/}
         {/*</Box>*/}
         
         <Stack direction="row" spacing={0} sx={{ height: '100%' }}>

            <Box className='menu-bar-vertical' />
           
            <Box className='background-box' sx={{ display: 'flex', flexDirection: 'column' }}>

               <AppBar position='static' elevation={0}>
                  <Toolbar variant="dense" sx={{backgroundColor: 'white', fontFamily: 'Lato'}}>
                     <PersonIcon sx={{ mr: 2, backgroundColor: '#3F51B5'}} />
                  </Toolbar>
               </AppBar>

               <Box className='box-container'>

                  <Card
                     elevation={10}
                     sx={{
                        backgroundColor: 'white',
                        borderRadius: '20px',
                        width: '40%',
                        height: '60%'}}>
                     <CardContent>
                        <Typography variant='h4' align='center' sx={{ fontWeight:'700' ,fontSize: '2rem' }}>
                           Login
                        </Typography>
                     </CardContent>
               </Card>
               </Box>
             </Box>
            
           
         </Stack>
      </div>

   )
}