import { AppBar, Avatar, Box, Button, Card, CardContent, CircularProgress, Stack, TextField, Toolbar, Typography } from '@mui/material';
import PersonIcon from '@mui/icons-material/Person';
import meshBackground from '../assets/LavaLamp_bg.png'
import './HomePage.scss'
import '../ReusableComponents/SplitText'
import SplitText from '../ReusableComponents/SplitText';
import { useGetEmployeesQuery } from '../Employees/routes';
import { useGetAccountsQuery } from '../Accounts/routes';

const HomePage = () => {
   // Grab both the data and the isLoading state
   const { data: employeesData, isLoading: employeesLoading } = useGetEmployeesQuery();
   const { data: accountsData, isLoading: accountsLoading } = useGetAccountsQuery();

   return (
      <Box className='outer-box' sx={{ pb: 5 }}>
         <AppBar position="static" elevation={0} sx={{ alignSelf: 'flex-start' }}>
            <Toolbar sx={{ backgroundColor: 'white', fontFamily: 'Roboto' }}>
               <PersonIcon sx={{ mr: 2, backgroundColor: '#3F51B5' }} />
            </Toolbar>
         </AppBar>

         {/* =========================================
             1. HEADER SECTION (Dashboard Overview)
             ========================================= */}
         <Stack
            direction='column'
            spacing={2}
            sx={{
               display: 'flex',
               width: '100%',
               justifyContent: 'flex-start',
               alignItems: 'flex-start',
               pl: 5,
               mt: 4,
               //border: '8px solid black'
            }}>

            <Box sx={{
               maxWidth: '600px',
               display: 'flex',
               flexDirection: 'column',
               alignItems: 'flex-start',
               gap: 2,
            }}>

               <SplitText
                  text='Dashboard Overview'
                  className='overview-split-text'
                  delay={50}
                  duration={1}
                  splitType="words"
                />

               <Box sx={{
                  display: 'flex',
                  alignItems: 'flex-start',
                  flexDirection: 'column',
                  gap: 0,
               }}>
                  <SplitText
                     text="Welcome to your admin dashboard."
                     className='description-split-text'
                     delay={50}
                     duration={1}
                     splitType="lines"
                  />
                  <SplitText
                     text="Here you can manage your profile and track projects, employees, and departments."
                     className='description-split-text'
                     delay={50}
                     duration={2}
                     splitType="lines"
                  />
               </Box>
            </Box>
         </Stack>
         {/* Title */}


         {/* =========================================
            2. UPPER SECTION (Admin Profile & Key Summary)
             ========================================= */}
         <Box
            sx={{
               display: 'flex',
               height: '400px',
               margin: 5,
            }}
         >

            <Stack
               direction="row"
               spacing={3}
               sx={{
                  display: 'flex',
                  alignItems: 'center',
                  justifyContent: 'flex-start',
                  width: '100%',
               }}
            >
               {/* User Card */}
               <Card
                  elevation={10}
                  className='user-card'
                  sx={{
                     height: '250px',
                     width: '420px',
                     borderRadius: '20px',
                     backgroundImage: `url(${meshBackground})`,
                     backgroundSize: 'cover',
                     backgroundPosition: 'center',
                     display: 'flex',
                     alignItems: 'center',
                     justifyContent: 'center'
                  }}>
                  <CardContent>
                     <Stack direction='column' spacing={3} alignItems='center'>

                        <Avatar sx={{ width: 80, height: 80, bgcolor: 'rgba(255, 255, 255, 0.4)' }}>
                           <PersonIcon sx={{ color: 'rgba(255, 255, 255, 0.4)', fontSize: 75 }} />
                        </Avatar>

                        <Typography variant='body1' align='center' sx={{ color: 'white', fontWeight: '500', fontSize: 25 }}>
                           Admin Profile
                        </Typography>

                     </Stack>
                  </CardContent>
               </Card>

               {/* --- RIGHT: Key Summary + Small Cards --- */}
               <Stack
                  direction='column'
                  spacing={2}
                  sx={{
                     width: '50%',
                     height: '80%',
                     alignSelf: 'flex-start',
                     display: 'flex',
                     alignItems: 'flex-start',
                     justifyContent: "flex-start",
                     pt: 3
                  }}>
                  <SplitText
                     text='Key Summary'
                     className='key-summary-split-text'
                     delay={50}
                     splitType="words"
                  />

                  {/* 3 Small Cards Stack */}
                  <Stack
                     direction='row'
                     spacing={2}
                     className='summary-stack'
                     sx={{
                        display: 'flex',
                        justifyContent: 'flex-start',
                        alignItems: "flex-start"
                     }}>

                     { /*Total Employees */}
                     <Card
                        elevation={10}
                        className='summary-card'
                        sx={{
                           backgroundImage: `url(${meshBackground})`,
                           borderRadius: '1.5vw',

                        }}>

                        <CardContent sx={{ height: '100%', width: '100%' }}>
                           <Stack direction='column' height='100%' justifyContent='flex-end' marginTop='15px'>

                              <Avatar sx={{
                                 width: 30,
                                 height: 30,
                                 bgcolor: 'rgba(255, 255, 255, 0.4)',
                                 alignSelf: 'flex-end',
                                 mb: 3
                              }}>
                                 <PersonIcon sx={{ color: 'rgba(255, 255, 255, 0.4)', fontSize: 25 }} />
                              </Avatar>

                              <Typography variant='body1' align='left' sx={{ color: 'white', fontWeight: '400', fontSize: 20 }}>
                                 Total Employees
                              </Typography>

                              <Typography variant='body1' align='left' sx={{ color: 'white', fontWeight: '500', fontSize: 30 }}>
                                 {employeesLoading ?
                                    (
                                       <CircularProgress size={30} sx={{ color: 'white' }} />
                                    ) : (
                                    employeesData?.length || 0
                                 )}
                              </Typography>

                           </Stack>
                        </CardContent>
                     </Card>

                     { /* Total Departments */}
                     <Card
                        elevation={10}
                        className='summary-card'
                        sx={{
                           backgroundImage: `url(${meshBackground})`,
                           borderRadius: '1.5vw'
                        }}>
                        <CardContent sx={{ height: '100%', width: '100%' }}>
                           <Stack direction='column' height='100%' justifyContent='flex-end' marginTop='15px'>

                              <Avatar sx={{ width: 30, height: 30, bgcolor: 'rgba(255, 255, 255, 0.4)', alignSelf: 'flex-end', mb: 3 }}>
                                 <PersonIcon sx={{ color: 'rgba(255, 255, 255, 0.4)', fontSize: 25 }} />
                              </Avatar>

                              <Typography variant='body1' align='left' sx={{ color: 'white', fontWeight: '400', fontSize: 20 }}>
                                 Total Departments
                              </Typography>

                              <Typography variant='body1' align='left' sx={{ color: 'white', fontWeight: '500', fontSize: 30 }}>
                                 0
                              </Typography>
                           </Stack>
                        </CardContent>
                     </Card>

                  </Stack>
               </Stack>
            </Stack>
         </Box>

         {/* =========================================
             3. LOWER SECTION (Bottom Cards)
             ========================================= */}
         <Box
            sx={{
               display: 'flex',
               width: '100%',
               maxWidth: '1400px',
            }}>
            <Stack
               direction='row'
               spacing={9}
               sx={{
                  display: 'flex',
                  justifyContent: 'center',
                  width: '100%',
                  height: '100%',
                  ml: 2
               }}>
                  {/* LEFT COLUMN: Profile Edit Card */}
                  <Card
                     elevation={10}
                     sx={{
                        display: 'flex',
                        height: '400px',
                        width: '30%',
                        borderRadius: '20px',
                     }}>
                     <CardContent
                     sx={{ width: '100%', height: '100%'}}>
                     <Stack
                        direction='column'
                        spacing={4}
                        sx={{
                           height: '100%',
                           width: '100%',
                           display: 'flex',
                           alignItems: 'flex-start',
                           mt: 3
                        }}>
                           <Typography variant='h3' align='left' sx={{ fontWeight: '500', fontSize: '1.4rem' }}>
                              Profile Edit
                           </Typography>
                           
                           <TextField
                              variant='standard'
                              label="Username"
                              placeholder='Username'
                              sx={{
                                 width: "90%"
                              }} />
                           
                           <TextField
                              variant='standard'
                              label="Password"
                              type='password'
                              placeholder='Password'
                               sx={{
                                  width: "90%"
                               }} />

                        <Button
                           variant="contained"
                           sx={{
                              width: '40%',
                              backgroundColor: "#6169FF"
                           }}>
                              Update
                           </Button>
                        </Stack>
                     </CardContent>
                  </Card>
                  
                  {/* RIGHT COLUMN: Users & Projects Cards */}
               <Stack
                  direction='column'
                  spacing={0}
                  height='100%'
                  width='60%'
                  sx={{
                     display: 'flex',
                     alignItems: 'flex-start',
                  }}>
                  
                  <SplitText
                     text='Admin Dashboard'
                     className='admin-dashboard-text'
                     delay={50}
                     splitType='words'/>

                  <Stack
                     direction='row'
                     spacing={3}
                     sx={{
                        alignItems: 'flex-start',
                        height: '400px',
                        width: '100%',
                     }}>
                        {/* Users Card */}
                        <Card
                           elevation={10}
                           className='admin-card'
                           sx={{ borderRadius: '20px', }}>
                           <CardContent
                              sx={{
                              width: '100%', height: '100%', p: 3
                              }}>
                              <Stack direction='column' spacing={3} height='100%' >

                                 <Typography variant='body1' sx={{ fontWeight: '500', fontSize: 18 }}>
                                    Users
                                 </Typography>

                                 <Typography variant='h2' sx={{ fontWeight: '500', fontSize: 40 }}>
                                    {accountsLoading?
                                       (
                                          <CircularProgress size={30} sx={{ color: 'white' }} />
                                       ) : (
                                          accountsData?.length || 0
                                       )}
                                 </Typography>
                              </Stack>
                           </CardContent>
                        </Card>
                  
                        {/* Projects Card */}
                        <Card
                           elevation={10}
                           className='admin-card'
                           sx={{ borderRadius: '20px' }}>
                           <CardContent sx={{ height: '100%', p: 3, }}>
                              <Stack direction='column' spacing={3} height='100%'>

                                 <Typography variant='body1' sx={{ fontWeight: '500', fontSize: 18 }}>
                                       Projects
                                  </Typography>
                                 
                                 <Typography variant='h2' sx={{ fontWeight: '500', fontSize: 40 }}>
                                      0
                                 </Typography>

                              </Stack>
                           </CardContent>
                        </Card>
                  
                     </Stack>
                  </Stack>
            </Stack>
         </Box>
      </Box>
   )

}

export default HomePage;