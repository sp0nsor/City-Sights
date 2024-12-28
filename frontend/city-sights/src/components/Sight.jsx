import {
  Text,
  Button,
  Card,
  CardHeader,
  Heading,
  Divider,
  CardBody,
  Stack,
  Box,
  Image,
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalCloseButton,
  ModalBody,
  useDisclosure,
  Input,
  Textarea,
} from "@chakra-ui/react";
import { useState } from "react";

export default function Sight({ sight, onPostReview }) {
  const { isOpen, onOpen, onClose } = useDisclosure();

  const [reviewData, setReviewData] = useState({
    title: "",
    reviewText: "",
    rating: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setReviewData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = () => {
    const review = {
      sightId: sight.id,
      ...reviewData,
    };

    onPostReview(review);
    onClose();
  };

  return (
    <Card variant={"outline"}>
      <CardHeader>
        <Heading size={"md"}>Название: {sight.name}</Heading>
      </CardHeader>
      <CardBody>
        <Text fontSize={"md"}>Описание: {sight.descriptions}</Text>
        {sight.imagePath && (
          <Image
            src={`data:image/jpeg;base64,${sight.imagePath}`}
            alt={sight.name}
            borderRadius="lg"
            mb={4}
          />
        )}
        <Text fontSize={"lg"}>Отзывы: </Text>
        <Stack spacing={2} ml={10}>
          {sight.reviews.map((review, index) => (
            <Box key={review.Id || index}>
              <Divider
                borderStyle={"dashed"}
                borderColor={"black"}
                borderWidth={"2px"}
                mb={2}
              />
              <Text fontWeight="bold">Название: {review.title}</Text>
              <Text>Описание: {review.reviewText}</Text>
              <Text color="gray.500">Оценка: {review.rating}</Text>
              <Divider
                borderStyle={"dashed"}
                borderColor={"black"}
                borderWidth={"2px"}
                mb={2}
              />
            </Box>
          ))}
        </Stack>
        <Button backgroundColor={"teal.300"} ml={10} onClick={onOpen}>
          +
        </Button>
      </CardBody>

      <Modal isOpen={isOpen} onClose={onClose}>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>Добавить отзыв</ModalHeader>
          <ModalCloseButton />
          <ModalBody className="flex flex-col gap-3">
            <Input
              placeholder="Название"
              name="title"
              value={reviewData.title}
              onChange={handleChange}
            />
            <Textarea
              placeholder="Отзыв"
              name="reviewText"
              value={reviewData.reviewText}
              onChange={handleChange}
            />
            <Input
              placeholder="Оценка (1-5)"
              name="rating"
              type="number"
              value={reviewData.rating}
              onChange={handleChange}
            />
            <Button backgroundColor={"teal.300"} onClick={handleSubmit}>
              Отправить
            </Button>
          </ModalBody>
        </ModalContent>
      </Modal>
    </Card>
  );
}
