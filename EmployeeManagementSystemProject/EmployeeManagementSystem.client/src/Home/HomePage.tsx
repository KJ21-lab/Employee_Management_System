import { Avatar, Box, Card, CardContent, Stack, TextField, Typography } from '@mui/material';
import PersonIcon from '@mui/icons-material/Person';
import meshBackground from '../assets/LavaLamp_bg.png'
import './HomePage.scss'
import '../ReusableComponents/SplitText'
import SplitText from '../ReusableComponents/SplitText';
import { useGetEmployeesQuery } from '../Employees/routes';
import { useGetAccountsQuery } from '../Accounts/routes';

const HomePage = () => {
   const employees = useGetEmployeesQuery();
   const accounts = useGetAccountsQuery();

   return (
      <Box className='outer-box' sx={{ pb: 5 }}>

         {/* =========================================
             1. HEADER SECTION (Dashboard Overview)
             ========================================= */}
         <Stack
            direction='column'
            spacing={2}
            sx={{ width: '100%', alignItems: 'flex-start', pl: 10, pt: 5, border: "8px solid black" }}
         >
            <SplitText
               text='Dashboard Overview'
               className='welcome-split-text'
               delay={50}
            />
            <SplitText
               text='Welcome to your admin dashboard.'
               className='description-split-text'
               delay={50}
            />
         </Stack>
         {/* Title */}


        

         {/* =========================================
             2. UPPER SECTION (Admin Profile & Key Summary)
             ========================================= */}
         <Box
            sx={{
               display: 'flex',
               // gridTemplateColumns: '35% 1fr',
               //gap: 8,
               //width: '100%',
               //maxWidth: '1400px',
               //mt: 15,
               //pb: 5,
               //ml: 10,
               height: '400px',
               margin: 5,
               border: "8px solid black"
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
                  border: "8px solid black"
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
                  }}
               >
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
               <Box
                  sx={{
                     flexDirection: 'column',
                     gap: 0,
                     border: "8px solid black",
                     width: '50%',
                     display: 'flex',
                     alignItems: 'flex-start',
                     justifyContent: "flex-start",
                     alignSelf: 'flex-start'
               }}>
                  <SplitText
                     text='Key Summary'
                     className='key-summary-split-text'
                     delay={50}/>

                  {/* 3 Small Cards Stack */}
                  <Stack
                     direction='row'
                     spacing={2}
                     className='summary-stack'
                     sx={{
                        width: "100%",
                        display: 'flex',
                        border: "8px solid black",
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
                              <Avatar sx={{ width: 30, height: 30, bgcolor: 'rgba(255, 255, 255, 0.4)', alignSelf: 'flex-end', mb: 3 }}>
                                 <PersonIcon sx={{ color: 'rgba(255, 255, 255, 0.4)', fontSize: 25 }} />
                              </Avatar>
                              <Typography variant='body1' align='left' sx={{ color: 'white', fontWeight: '400', fontSize: 20 }}>
                                 Total Employees
                              </Typography>
                              <Typography variant='body1' align='left' sx={{ color: 'white', fontWeight: '500', fontSize: 30 }}>
                                 {employees.data?.length}
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
               </Box>
            </Stack>
         </Box>

         {/* =========================================
             3. LOWER SECTION (Bottom Cards)
             ========================================= */}
         <Box
            sx={{
               display: 'grid',
               gridTemplateColumns: '35% 1fr',
               gap: 5,
               width: '100%',
               maxWidth: '1400px',
               mt: 5,
               pb: 5,
               ml: 10,
               border: "8px solid black"
            }}
         >
            {/* LEFT COLUMN: Change Credentials Card */}
            <Card
               elevation={10}
               sx={{
                  height: '400px',
                  width: '90%',
                  borderRadius: '20px',
               }}>
               <CardContent>
                  <Stack direction='column' spacing={4} sx={{ mt: 3, px: 2, p: 4 }}>
                     <Typography variant='h3' align='left' sx={{ fontWeight: '500', fontSize: '1.4rem' }}>
                        Change credentials
                     </Typography>
                     <TextField
                        variant='standard'
                        label="Username"
                        placeholder='Username'
                        fullWidth
                     />
                     <TextField
                        variant='standard'
                        label="Password"
                        type='password'
                        placeholder='Password'
                        fullWidth
                     />
                  </Stack>
               </CardContent>
            </Card>

            {/* RIGHT COLUMN: Users & Projects Cards */}
            <Stack direction='column' spacing={0} height='100%' width='100%' >

               <SplitText text='Admin Dashboard' className='admin-dashboard-text' delay={50} />

               <Stack direction='row' spacing={3} sx={{ alignItems: 'center', height: '400px', width: '100%', border: "8px solid black" }}>
                  {/* Users Card */}
                  <Card
                     elevation={10}
                     className='admin-card'
                     sx={{ borderRadius: '20px', }}>
                     <CardContent sx={{ width: '100%', height: '100%', p: 3 }}>
                        <Stack direction='column' spacing={3} height='100%' >
                           <Typography variant='body1' sx={{ fontWeight: '500', fontSize: 18 }}>
                              Users
                           </Typography>
                           <Typography variant='h2' sx={{ fontWeight: '500', fontSize: 40 }}>
                              {accounts.data?.length || 0}
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

         </Box>

      </Box>
   )

}

export default HomePage;