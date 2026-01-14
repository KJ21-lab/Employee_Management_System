import { Avatar, Box, Card, CardContent, Stack, Typography } from '@mui/material';
import PersonIcon from '@mui/icons-material/Person';
import meshBackground from '../assets/LavaLamp_bg.png'
import './HomePage.scss'
import '../ReusableComponents/SplitText'
import SplitText from '../ReusableComponents/SplitText';

const HomePage = () => {

   return (
      <Box sx={{
         minheight: '100%',
         height: 'auto',
         width: '100%',
         display: 'flex',
         alignItems: 'center',
         justifyContent: 'flex-start',
         flexDirection: 'column',
         pt: 5,
         pb: 5
      }}>
         <Stack
            direction='column'
            spacing={1}
            sx={{ height: '100%', width: '100%', alignItems: 'flex-start', pl: 10 }}>
            <SplitText
               text='Dashboard Overview'
               className='welcome-split-text'
               delay={100}
               duration={0.6}
               ease="power3.out"
               splitType="chars"
               from={{ opacity: 0, y: 40 }}
               to={{ opacity: 1, y: 0 }}
               threshold={0.1}
               rootMargin="-100px" />

            <SplitText
               text='Welcome to your admin dashboard.'
               className='description-split-text'
               delay={100}
               duration={0.6}
               ease="power3.out"
               splitType="chars"
               from={{ opacity: 0, y: 40 }}
               to={{ opacity: 1, y: 0 }}
               threshold={0.1}
               rootMargin="-100px" />

         </Stack>
         <Stack
            direction="row"
            spacing={0}
            sx={{
               minHeight: '50vh',
               width: '100%',
               alignItems: 'center',
               justifyContent: 'center',
               mt: 20,
            }}>

            <Card
               className='user-card'
               elevation={10}
               sx={{
                  backgroundImage: `url(${meshBackground})`,
                  borderRadius: '1.5vw',
                  position: 'relative',
                  ml: 10,
                  alignItems: 'center',
                  justifyContent: 'center'
               }} >
               <CardContent>
                  <Stack direction='column' spacing={5} alignItems='center'>
                     <Avatar
                        sx={{
                           width: 80,
                           height: 80,
                           bgcolor: 'rgba(255, 255, 255, 0.4)',
                        }}
                     >
                        <PersonIcon
                           sx={{
                              color: 'rgba(255, 255, 255, 0.4)',
                              fontSize: 75,
                           }}
                        />
                     </Avatar>

                     <Typography
                        variant='body1'
                        align='center'
                        sx={{ color: 'white', fontWeight: '450', fontSize: 25 }}>
                        Admin Profile
                     </Typography>

                  </Stack>
               </CardContent>
            </Card>

            <Stack
               direction='row'
               spacing={2}
               className='summary-stack'
               sx={{
                  '&::-webkit-scrollbar': { display: 'none' },
                  msOverflowStyle: 'none',
                  scrollbarWidth: 'none',
                  mb: 15,
                  mr: 20,
                  p: 5
               }}>
               <Card
                  elevation={10}
                  className='summary-card'
                  sx={{ backgroundImage: `url(${meshBackground})`, borderRadius: '1.5vw' }} />
               <Card
                  elevation={10}
                  className='summary-card'
                  sx={{ backgroundImage: `url(${meshBackground})`, borderRadius: '1.5vw' }} />
               <Card
                  elevation={10}
                  className='summary-card'
                  sx={{ backgroundImage: `url(${meshBackground})`, borderRadius: '1.5vw' }} />
            </Stack>

         </Stack>

         <Stack
            direction="row"
            spacing={5}
            sx={{
               minHeight: '50vh',
               width: '100%',
               alignItems: 'center',
               justifyContent: 'flex-start',
               pl: 10,
               mt: 10,
            }}>
            <Card
               elevation={10}
               sx={{
                  height: '100%',
                  width: '40%',
                  backgroundSize: 'cover',
                  backgroundRepeat: 'no-repeat',
                  backgroundPosition: 'center',
                  borderRadius: '20px',
                  overflow: 'hidden',
                  display: 'flex',
               }}>
            </Card>

            <Stack
               direction='row'
               spacing={2}
               className='summary-stack'
               sx={{
                  '&::-webkit-scrollbar': { display: 'none' },
                  msOverflowStyle: 'none',
                  scrollbarWidth: 'none',
                  p: 5,
               }}>
               <Card
                  elevation={10}
                  className='admin-dashboard'
                  sx={{ borderRadius: '1.5vw' }} />
               <Card
                  elevation={10}
                  className='admin-dashboard'
                  sx={{ borderRadius: '1.5vw' }} />
               <Card
                  elevation={10}
                  className='admin-dashboard'
                  sx={{ borderRadius: '1.5vw' }} />
            </Stack>
         </Stack>

      </Box>
   )

}

export default HomePage;