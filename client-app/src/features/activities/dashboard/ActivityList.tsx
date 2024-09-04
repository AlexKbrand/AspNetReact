import { SyntheticEvent, useState } from "react";
import { Activity } from "../../../app/models/activity";
import { Segment, Item, Button, Label } from "semantic-ui-react";

interface Props {
  activities: Activity[]; // Replace with your own Activity type definition.
  selectActivity: (id: string) => void;
  deleteActivity: (id: string) => void;
  submitting: boolean; //
}

export default function ActivityList({
  activities,
  selectActivity,
  deleteActivity,
  submitting,
}: Props) {
  const [target, setTaget] = useState("");

  function handleActivityDelete(
    event: SyntheticEvent<HTMLButtonElement>,
    id: string
  ) {
    event.preventDefault();
    setTaget(event.currentTarget.name);
    deleteActivity(id);
  }
  return (
    <Segment>
      <Item.Group divided>
        {activities.map((activity) => (
          <Item key={activity.id}>
            <Item.Content>
              <Item.Header as="a">{activity.title}</Item.Header>
              <Item.Meta>
                <span>{activity.date}</span>
              </Item.Meta>
              <Item.Description>
                <div>{activity.description}</div>
                <div>
                  {activity.city}, {activity.venue}
                </div>
              </Item.Description>
            </Item.Content>
            <Item.Extra>
              <Button
                floated="right"
                content="View"
                color="blue"
                onClick={() => selectActivity(activity.id)}
              ></Button>
              <Button
                name={activity.id}
                onClick={(e) => handleActivityDelete(e, activity.id)}
                floated="right"
                content="Delete"
                color="red"
                loading={submitting && target === activity.id}
              />
              <Label basic content={activity.category} />
            </Item.Extra>
          </Item>
        ))}
      </Item.Group>
    </Segment>
  );
}
