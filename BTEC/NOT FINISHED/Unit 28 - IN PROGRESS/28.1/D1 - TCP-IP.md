# D1 - TCP/IP and Application Layer Protocols

### What is TCP/IP?
TCP/IP is how nearly all communication takles place over the internet. It stands for 'Transmission Control Protocol (over) Internet Protocol'.  
This means it is a protocol that controls transmissions, using the Internet Protocol as a base for routing data.  
The IP allows one computer to talk to another, and route traffic over networks, be it a home/office network or the entire internet.  
The Transmission Control Protocol handles breaking the transmission into packets, and re-assembling them at the othe end. Different packets might take different routes as it is the IP that determines the route, but the TCP will still assemble them at the destination.  
TCP/IP uses the client-server model - that is, the computer sending the transmission acts as the server (and may in fact be an actual server), and the recipient is a client of the server. Each transmission is point-to-point. This means that each transmission is only between two computers.  
Most other protocols are built on top of TCP/IP. The protocol is responsible for the data in the transmission, but TCP/IP handles the making and assembling packets
