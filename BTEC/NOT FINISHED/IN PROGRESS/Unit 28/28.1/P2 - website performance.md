#<p align="center">P2 - Factors that Affect the Performance of a Website<p>

###Client Factors
The first part of loading a website is connecting to a server. The time this takes is called the ping - how long it takes to send a packet to a server and get a response.
On a LAN pings are usually under a millisecond, but over a WAN or the internet, could take a few hundred milliseconds to a few seconds. Ping is determined by the clients internet speed, and the physical distance from the server.  
Ping will affect the time required to establish a connection, as well as the latency of real-time client-server communication, such as streaming a live video.   
Once the connection is established, the clients browser requests a webpage. This will include the HTML, CSS and any assets specified in either (such as fonts, images or scripts).  
The speed of the clients internet connection will determine how long the page takes to download. On a slow connection, text and other 'small' elements will load quickly, but images, videos, flash objects and other 'large' elements will take a long time to download.  
Even on a fast internet connection, the loading of the page may be delayed by how long it takes the browser to render the website, particularly on a slow computer. Older computers may have an upper limit on the connection speed, as well as slower/less RAM, a slower CPU/GPU, meaning it will take longer to download the webpage, proccess it, and display it in the browser.

###Server Factors
Just like the client, the server has a ping between itself and the clients. This ping will vary based on server load (how much it's doing), the number of clients, the distance to the clients, and the speed of the servers internet connection.  
As a server serves a website to multiple clients, the performance on the clients end will be largely determined by the how busy the website. Once there are too many clients, the server will not be able to respond quickly enough to most of them, and the connection will time out. This will result in people being unable to access the website, or having to wait a long time for things to load.  
Server load is not only determined by the number of clients, but also by how much server-side processing the website utilises. Many websites use the clients PC to reduce latency and server load, but for some websites this is not possible. For example, the client may not have access to a dataset that is being processed, so the server must do it instead.  
Ignoring server load, the other biggest factor of a websites performance is the upload speed of the server - how quickly it can send webpages.  
This is also affected by the size of the webpage - larger websites take more bandwidth, time and resources to send. 