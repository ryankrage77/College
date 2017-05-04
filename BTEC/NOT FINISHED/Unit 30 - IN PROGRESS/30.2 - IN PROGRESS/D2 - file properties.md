#D2 - File Properties

Various compression methods exist to reduce file sizes, making images quicker to transfer and load.


There are different ‘levels’ of lossy compression, and most image editing software and digital cameras will allow the user to adjust these.   
The first parameter is the image resolution, or size. An image created at a resolution of 1920\*1080 could be downscaled to 1330*768, reducing the number of pixels from 2073600 to 1021440. With 32-bit colour depth, that would reduce the file size from 8Mb to 5.4Mb.  
If the image is downscaled further, the file size would be even smaller.  
However, reducing the resolution means the image is smaller, and therefore the quality is lower. 1080p and 768p are fairly easy to tell apart with the naked eye, and the difference is more severe the more downscaling there is.
The colour depth can also be reduced. Colour depth refers to the number of bits used to store the colour of each pixel. One bit can store two colours (usually black and white), two bits can store four colours, a byte can store 256 colours, and so on. The human eye can see 16.7 million different colours, so 24-bit colour is referred to as ‘true colour’. Generally, 32-bit colour is used as it is an easier number for computers to work with.  
The most common way to lossily compress a file is by creating it as a .JPG or .JPEG file.  
The JPEG (Joint Photographic Experts Group, who created the file format) standard compresses images when they are created. Most cameras save images in this format.  
Other formats use lossless compression – the file size is reduced, but without reducing the image quality.  
The main way this is done is by finding patterns of pixels – areas of the picture that are all one colour. The simplest method is looking for a row of pixels that are the same colour.
Once this has been done to the whole image, file sizes tend to be reduced by around 30%, although this depends on the image. More complex images are harder to compress, while an image that is a single colour would be very easy to compress.  
More complex compression techniques can spot more complex patterns over larger parts of the image and reduce file sizes even further.  
One potential application of this technique is using it to generate parts of images on the fly. For example, in a video stream it may one day be possible to encode an area of an image as a texture (say, ‘grass’ or ‘sky’) and the device receiving the stream will simply generate that part of the image by filling it in with a randomly generated texture, rather than having to download a hard-to-compress video stream.